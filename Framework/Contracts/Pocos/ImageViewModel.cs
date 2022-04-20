using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.framework.Contracts.Pocos
{
    class ImageViewModel
    {
        public class ImageInfo
        {
            public string ImageUrl { get; set; }
            public string Name { get; set; }
            public int itemId { get; set; }

            public ImageInfo(string imgpath, string imgName, int _itemId)
            {
                this.ImageUrl = imgpath;
                this.Name = imgName;
                this.itemId = _itemId;
            }

            public ImageInfo()
            {
            }
        }
        public class Image
        {
            public string ImgUrl { get; set; }

            public Image(string imgpath)
            {
                this.ImgUrl = imgpath;
            }
        }


        public class WalletInfo
        {
            public string ImageUrl { get; set; }
            public string Name { get; set; }
            public int itemId { get; set; }

            public WalletInfo(string imgpath, string imgName, int _itemId)
            {
                this.ImageUrl = imgpath;
                this.Name = imgName;
                this.itemId = _itemId;
            }
        }

    }
}
