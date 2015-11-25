﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
/// <summary>
/// server side control
/// </summary>
public partial class _Default : System.Web.UI.Page
{
     /// <summary>
     /// output all the posts that are currently stored in the directory
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
     {
          DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Appdata"));
          var directories = di.GetFiles("*", SearchOption.AllDirectories);
          String done="";
          foreach (FileInfo d in directories)
          {
               done+="<h1>"+d.Name.Substring(0,d.Name.IndexOf("."))+"</h1>";
               done += "<hr>";
               done += "<img src=\"../Appdata/"+ d.Name + "\">";
               //done+="<asp:PlaceHolder runat=\"server\" ID=\"" + d.Name + "\" Visible =\"false\">";
               //done+="<input type=\"file\" runat=\"server\" id=\""+d.Name+"\" accept=\".gif,.jpg,.tif\"/>";
               //done +="<asp:button runat=\"server\" ID=\""+d.Name +"Text=\"submit\" onclick=\"comment_click\" />";
               //done +="</asp:PlaceHolder>";
               done += "<hr size=\"15\">";
          }
          post.InnerHtml = done;
    }

     /// <summary>
     /// make the new post form appear
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
    protected void newpostbtn_click(object sender, EventArgs e)
    {
        newPost.Visible = true;
        unhide.Visible = false;
    }
     /// <summary>
     /// stored the title of the post and the picture post into local directory(name the picture file as the title of the post from the textbox
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
    protected void submitbtn_click(object sender, EventArgs e)
    {
         unhide.Visible = true;
        newPost.Visible = false;
        String t = title.Value;
        HttpPostedFile image=pic.PostedFile;
        int s=image.FileName.IndexOf(".");
        String r = image.FileName.Substring(s);
        var path = Path.Combine(Server.MapPath("~/Appdata"), t+r);
        image.SaveAs(path);
        Page_Load(sender, e);
    }
     
     /// <summary>
     /// unfinished comment method after comment button clicked
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
    protected void comment_click(object sender, EventArgs e)
    {
         Button c=(Button)sender;
         ///Application.Contents;
         HttpPostedFile image;
         ///var path = Path.Combine(Server.MapPath("~/Appdata"), t + r);
         ///image.SaveAs(path);
         
    }


}