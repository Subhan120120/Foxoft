
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;

namespace Foxoft
{
    public partial class XtraForm1 : XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            //gc.Dock = DockStyle.Fill;
            this.Controls.Add(gc);

            Image im1 = Image.FromFile("D:\\BMW.jpg");
            Image im2 = Image.FromFile("D:\\BMW.jpg");
            Image im3 = Image.FromFile("D:\\BMW.jpg");
            Image im4 = Image.FromFile("D:\\BMW.jpg");
            Image im5 = Image.FromFile("D:\\BMW.jpg");
            Image im6 = Image.FromFile("D:\\BMW.jpg");

            gc.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            gc.Gallery.ImageSize = new Size(50, 30);
            gc.Gallery.ShowItemText = true;

            GalleryItemGroup group1 = new GalleryItemGroup();
            group1.Caption = "Cars";
            gc.Gallery.Groups.Add(group1);

            GalleryItemGroup group2 = new GalleryItemGroup();
            group2.Caption = "People";
            gc.Gallery.Groups.Add(group2);

            group1.Items.Add(new GalleryItem(im1, "BMW", ""));
            group1.Items.Add(new GalleryItem(im2, "Ford", ""));
            group1.Items.Add(new GalleryItem(im3, "Mercedec-Benz", ""));

            group2.Items.Add(new GalleryItem(im4, "Anne Dodsworth", ""));
            group2.Items.Add(new GalleryItem(im5, "Hanna Moos", ""));
            group2.Items.Add(new GalleryItem(im6, "Janet Leverling", ""));
        }
    }
}