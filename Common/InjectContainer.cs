using System;
using System.Collections.Generic;
using System.Reflection;

namespace Common
{
    public class InjectContainer
    {
        private static Dictionary<string, object> dicToInstances = new Dictionary<string, object>();
        private static Dictionary<string, List<Type>> dicReturnTypeInfo = new Dictionary<string, List<Type>>();
        private static object objLock = new object();

        /// <summary>
        /// 接口注册（接口类和实现类之间的约束是接口类名称为实现类名称前面加 I）
        /// </summary>
        /// <param name="fromNameSpace">接口类命名空间</param>
        /// <param name="toNameSpace">实现类命名空间</param>
        public void Register(string fromNameSpace, string toNameSpace)
        {
            var issembly = Assembly.Load(fromNameSpace);
            var toAssembly = Assembly.Load(toNameSpace);
            var types = issembly.GetTypes();
            foreach (var type in types)
            {
                if (dicToInstances.ContainsKey(type.FullName)) continue;
                var toType = toAssembly.GetType(string.Format("{0}.{1}", toNameSpace, type.Name.Substring(1)));
                var instance = Activator.CreateInstance(toType);
                dicToInstances.Add(type.FullName, instance);
            }
        }
        /// <summary>
        /// 获取实体（控制器每次访问都是要创建新实例的）
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetInstance<T>(Type type)
        {
            List<Type> listType = new List<Type>();
            if (dicReturnTypeInfo.ContainsKey(type.FullName))
            {
                //如果有类型数据就不需要再获取一次了
                listType = dicReturnTypeInfo[type.FullName];
            }
            else
            {
                lock (objLock)
                {
                    if (!dicReturnTypeInfo.ContainsKey(type.FullName))
                    {
                        var ConstructorInfo = type.GetConstructors();
                        var parameters = ConstructorInfo[0].GetParameters();

                        foreach (var item in parameters)
                        {
                            Type fromType = item.ParameterType;
                            listType.Add(fromType);

                        }
                    }
                }

            }
            List<object> param = new List<object>();
            foreach (var pType in listType)
            {
                if (dicToInstances.ContainsKey(pType.FullName))
                {
                    param.Add(dicToInstances[pType.FullName]);
                }
            }
            return (T)Activator.CreateInstance(type, param.ToArray());
        }


    }
}
