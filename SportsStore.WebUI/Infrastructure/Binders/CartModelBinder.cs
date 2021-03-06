﻿using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportsStore.WebUI.Infrastructure.Binders {
    public class CartModelBinder : IModelBinder {

        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {

            Cart cart = null;

            if (controllerContext.HttpContext.Session != null) {
                cart = controllerContext.HttpContext.Session[sessionKey] as Cart;
            }

            if (cart == null) {

                cart = new Cart();

                if (controllerContext.HttpContext.Session != null) {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }

            }

            return cart;
        }

    }
}
