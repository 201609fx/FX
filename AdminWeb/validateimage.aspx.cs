using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.UI;

public partial class validateimage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ValidateCode = CreateRandomCode(4);
        Session["ValidateCode"] = ValidateCode;
        CreateImage(ValidateCode);
    }

    private string CreateRandomCode(int codeCount)
    {
        int number;
        char code;
        string checkCode = String.Empty;

        Random random = new Random();

        for (int i = 0; i < codeCount; i++)
        {
            number = random.Next();

            //				if(number % 2 == 0)
            code = (char)('0' + (char)(number % 10));
            //				else
            //					code = (char)('A' + (char)(number % 26));

            checkCode += code.ToString();
        }
        return checkCode;
    }

    private void CreateImage(string checkCode)
    {
        Random random;
        int iwidth = (int)(checkCode.Length * 11.5);
        Bitmap image = new Bitmap(iwidth, 20);
        Graphics g = Graphics.FromImage(image);
        Font f = new Font("Verdana", 9,FontStyle.Bold);
        Brush b = new SolidBrush(Color.Black);
        //g.FillRectangle(new System.Drawing.SolidBrush(Color.Blue),0,0,image.Width, image.Height);
        g.Clear(Color.Gray);
        random = new Random();

        //for (int i = 0; i < 25; i++)
        //{
        //    int x1 = random.Next(image.Width);
        //    int x2 = random.Next(image.Width);
        //    int y1 = random.Next(image.Height);
        //    int y2 = random.Next(image.Height);

        //    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
        //}
        g.DrawString(checkCode, f, b, 0, 0);

        Response.ClearContent();
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        Response.Expires = -9999;
        Response.AddHeader("Pragma", "No-cache");
        Response.AddHeader("Cache-Control", "No-cache");
        Response.ContentType = "image/gif";
        image.Save(Response.OutputStream, ImageFormat.Gif);
        g.Dispose();
        image.Dispose();
    }
}
