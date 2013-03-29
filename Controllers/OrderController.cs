using System.Web.Mvc;
using Orchard.DisplayManagement;
using Orchard.Mvc;
using Orchard.Themes;

namespace Bolo.WebShop.Controllers
{
    public class OrderController : Controller 
    {
        private readonly dynamic _shapeFactory;

        public OrderController(IShapeFactory shapeFactory)
        {
            _shapeFactory = shapeFactory;
        }

        [Themed, HttpPost]
        public ActionResult Create()
        {

            var shape = _shapeFactory.Order_Created();
            return new ShapeResult(this, shape);
        }
    }
}