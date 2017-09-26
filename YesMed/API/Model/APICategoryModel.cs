using System.IO;
using YesMed.Models;

namespace YesMed.API.Model
{
    public class APICategoryModel
    {
        #region Properties
        public int ID { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        #endregion

        #region Ctors
        public APICategoryModel()
        { }
        public APICategoryModel(CategoryModel model, string imagePath)
        {
            ID = model.ID;
            Name = model.Name;
            Image = Path.Combine(imagePath, model.ImageName + ".PNG");
        }

        #endregion
    }
}
