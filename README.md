# GD.ImageEntry

Upgrade Repository => https://github.com/AlexVarrese/Xamarin.Forms.ImageEntry

Use images in your entrys
 
###### This is the component, works on iOS, Android.

UWP coming soon

<a href="#">
<img border="0" src="Resources/sample.png" width="400"   alt="SocialNetworkApp" /></a>
 
 **NuGet**

|Name|Info|
| ------------------- | :------------------: |
|ImageEntry|[![NuGet](https://img.shields.io/badge/nuget-1.0.7-blue.svg)](https://www.nuget.org/packages/Xamarin.Forms.ImageEntry/)|

**Platform Support**

ImageEntry is a .NET Standard 2.0 library.Its only dependency is the Xamarin.Forms

## Setup / Usage

Install the package on all projects.

iOS, in AppDelegate on FinishedLaunching start control  Xamarin.Forms.ImageEntry.ImageEntryRenderer.Init(); :

```csharp
   public override bool FinishedLaunching(UIApplication app, NSDictionary options)
   {
     global::Xamarin.Forms.Forms.Init();

     Xamarin.Forms.ImageEntry.ImageEntryRenderer.Init();

     LoadApplication(new App());

     return base.FinishedLaunching(app, options);
   }
```

Android in MainActivity on OnCreate start control passing the context as parameter  Xamarin.Forms.ImageEntry.ImageEntryRenderer.Init(this.BaseContext); :

```csharp
    protected override void OnCreate(Bundle savedInstanceState)
    {
      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(savedInstanceState);

      Xamarin.Forms.ImageEntry.ImageEntryRenderer.Init(this.BaseContext);

      global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
      LoadApplication(new App());
    }
```
in the Xaml file we must declare our control   xmlns:ie="clr-namespace:Xamarin.Forms.ImageEntry;assembly=Xamarin.Forms.ImageEntry", for example . 

Add the images in the project assets folders.

you can use the ImageAlignment tag to set whether the image will appear left or right.

```csharp

  <ie:ImageEntry TextColor="Black" 
                        PlaceholderColor="Black" 
                        Image="user" 
                        Placeholder="User" 
                        ImageAlignment="Right"
                        HorizontalOptions="FillAndExpand"/>
                
   <ie:ImageEntry TextColor="Black" 
                        PlaceholderColor="Black" 
                        Image="password" 
                        Placeholder="Password" 
                        HorizontalOptions="FillAndExpand"/>

```

The complete example can be downloaded here: https://github.com/TBertuzzi/Xamarin.Forms.ImageEntry/tree/master/ImageEntrySample

