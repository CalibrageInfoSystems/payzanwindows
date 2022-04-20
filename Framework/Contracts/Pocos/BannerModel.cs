using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.framework.Contracts.Pocos
{
    class BannerModel
    {
       
            public string ImageUrl { get; set; }
            public string Name { get; set; }
        public int itemId { get; set; }

        public BannerModel(string imgpath, string imgName, int _itemid)
            {
                this.ImageUrl = imgpath;
                this.Name = imgName;
            this.itemId = _itemid;
            }
        
    }
}
