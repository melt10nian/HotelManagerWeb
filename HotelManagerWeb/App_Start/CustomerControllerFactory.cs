using Common;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace HotelManagerWeb
{
    /// <summary>
    /// 自定义控制器生成类
    /// </summary>
    public class CustomControllerFactory : DefaultControllerFactory
    {
        private InjectContainer _Container = null;
        public CustomControllerFactory(InjectContainer container)
        {
            this._Container = container;
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
                return this._Container.GetInstance<IController>(controllerType);
            return null;
        }
    }
}