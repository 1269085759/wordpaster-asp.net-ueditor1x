using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace UEditor
{
	public partial class upload : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string fname = Request.Form["UserName"];
			int len = Request.ContentLength;

			if (Request.Files.Count > 0)
			{
				DateTime timeNow = DateTime.Now;
				string uploadPath = "/upload/" + timeNow.ToString("yyyyMM") + "/" + timeNow.ToString("dd") + "/";

				string folder = Server.MapPath(uploadPath);
				//自动创建目录
				if (!Directory.Exists(folder))
				{
					Directory.CreateDirectory(folder);
				}
				HttpPostedFile file = Request.Files.Get(0);
				string ext = Path.GetExtension(file.FileName).ToLower();
				//只支持图片上传
				if (ext == ".jpg"
                    || ext == ".jpeg"
					|| ext == ".png"
					|| ext == ".gif"
					|| ext == ".bmp")
				{
					string filePath = Path.Combine(folder, file.FileName);

                    //
                    if(!Directory.Exists(filePath)) file.SaveAs(filePath);
					Response.Write(uploadPath + file.FileName);
				}
			}
		}
	}
}
