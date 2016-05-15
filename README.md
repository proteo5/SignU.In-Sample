# SignU.In-Sample
This code is an application sample in ASP.NET MVC 4 for how to use the SignU.In authentication services. You can see it in action at [http://demo.signu.in](http://demo.signu.in)

The [SignU.In](http://signu.in) services are meant to help the developers have an easy way to implement authentication to their Websites and Web applications. Also eliminates the need to use and administrate passwords for the users.

###How was implemented?
 1.- Create a new ASP.Net Web Application.
 
![Create a new ASP.Net Web Application.](https://raw.githubusercontent.com/proteo5/SignU.In-Sample/master/Content/Pic1.png)

2.- Select the **MVC** template, and **change the Authentication method to "_No authentication_"**. 

![Select the template MVC](https://raw.githubusercontent.com/proteo5/SignU.In-Sample/master/Content/Pic2.png)

3.- Add a reference to the project.

![Add a reference to the project](https://raw.githubusercontent.com/proteo5/SignU.In-Sample/master/Content/Pic3.png)

4.- Go to the Browse section and add the reference to **Signu.In.MVCFilter.dll**. For now, you can download the dll at [here](https://github.com/proteo5/SignU.In-Sample/tree/master/Heachi.MVCFilter/bin/Release). Soon it will be added to NuGet.

![Go to the Browse](https://raw.githubusercontent.com/proteo5/SignU.In-Sample/master/Content/Pic4.png)

5.- Open the **"web.config"** file and add the following code in the **"system.web"** section:
```
<authentication mode="Forms">
    <forms name=".ASPXFORMS" loginUrl="https://signu.in/Home/Login?d=demo.signu.in" protection="All" path="/" timeout="30"/>
</authentication>
```
Change the **"?d=demo.signu.in"** with the actual url to your website when publish. 

![Open the web.config](https://raw.githubusercontent.com/proteo5/SignU.In-Sample/master/Content/Pic5.png)

6.- Open the file **"\App_Start\FilterConfig.cs"** and add:
```
//To use on production
//filters.Add(new SignU.In.MVCFilter.AuthenticationFilter());
            
//To use when developing
filters.Add(new SignU.In.MVCFilter.AuthenticationFilterDev());
```

![Open FilterConfig](https://raw.githubusercontent.com/proteo5/SignU.In-Sample/master/Content/Pic6.png)

7.- Open the file **"\Controllers\HomeController.cs"**, add the Logout ActionResult method and the ViewBag to the Index ActionResult:
```
public ActionResult Index()
{
	ViewBag.User = User.Identity.Name;
    return View();
}
public ActionResult Logout()
{
	System.Web.Security.FormsAuthentication.SignOut();
    return RedirectToAction("Index");
}
```

![Open HomeController](https://raw.githubusercontent.com/proteo5/SignU.In-Sample/master/Content/Pic7.png)

8.- Open the file **"\Views\Home\Index.cshtml"** and change the **div** with the **jumbotron** class with this code:
```
 <div class="jumbotron">
    <h1>ASP.NET with SignU.In</h1>
    <h3>Welcome @ViewBag.User</h3>
    <p class="lead">ASP.NET is a free web framework for building great Web sites 
    and Web applications using HTML, CSS and JavaScript.</p>
    <p><a href="/Home/logout" class="btn btn-primary btn-lg">Logout &raquo;</a></p>
</div>
```
![Open Index](https://raw.githubusercontent.com/proteo5/SignU.In-Sample/master/Content/Pic8.png)

###Testing the site. 
 At this point we have finish implementing SignU.In , but we are now in **developer mode**. 
 To test it:
 
 1.- Go to the properties of the web site and copy the url. 

![website properties](https://raw.githubusercontent.com/proteo5/SignU.In-Sample/master/Content/Pic9.png)

2.- Press **F5** to run the site. It will intermediately send you to the Signu.In site, but it won't work since we are in developer mode.

Paste the url that you copy at the address bar of the browser and add a Query string like this **"?d=test@test.com"**

![Run the site](https://raw.githubusercontent.com/proteo5/SignU.In-Sample/master/Content/Pic10.png)

3.- The **Dev** filter will allow you to authenticate with the test email that you provide. 

![Signing In](https://raw.githubusercontent.com/proteo5/SignU.In-Sample/master/Content/Pic11.png)

##Very Important Note :
###Please read all!
Please remember that we specify to use the **development** filter.

![Open FilterConfig](https://raw.githubusercontent.com/proteo5/SignU.In-Sample/master/Content/Pic6.png)

 The development filter will work only with **localhost**. 
Absolutely **never used it on the production  environment**, it will not work. 
For production environment switch the filter:  

![Open FilterConfig](https://raw.githubusercontent.com/proteo5/SignU.In-Sample/master/Content/Pic12.png)

Due to security reasons, the SignU.In authentication service **will not work** with a **"localhost"** domain name in any circumstances.

The features and implantation used for the production environment are **complete different** to the development environment.

The development environment is provided so it can be very easy for the developer to work in his website or web application.

Also, this service **only provides the authentication** for your site. 

**It will be needed that you implment the authorization.** 

It is very important to properly handle this on your site. 

Se [this article](http://www.bu.edu/tech/about/security-resources/bestpractice/auth/) as a reference 

For any questions please post it at [stackoverflow.com](http://stackoverflow.com) with the tag **"SignU.In"** and I will be happy to help.