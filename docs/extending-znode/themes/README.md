# Custom Themes

The Znode WebStore UI is rendered by [MCV Razor](https://docs.microsoft.com/en-us/aspnet/web-pages/overview/getting-started/introducing-razor-syntax-c) view templates. All templates and other content files (fonts, styles, etc.) are contained in a Znode 'theme'. These themes can be easily plugged in and switched at any time.

## Creating a Custom Theme

The following steps walk through the process of creating a new custom theme.

### Step 1: Copy Default Theme

To create a new custom theme, use the default theme as a starting point.

1. Make a copy of the [default theme](https://github.com/amlacommerce/znode/tree/master/ZnodeMultifront/Projects/Znode.Engine.WebStore/Views/Themes/Default) (or [B2B theme](https://github.com/amlacommerce/znode/tree/master/ZnodeMultifront/Projects/Znode.Engine.WebStore/Views/Themes/B2B)) in the '[Views/Themes](https://github.com/amlacommerce/znode/tree/master/ZnodeMultifront/Projects/Znode.Engine.WebStore/Views/Themes)' folder. Name the copied folder to the desired custom theme name. The name `NewTheme` is used as an example throughout these instructions.
1. **Important:** Commit the new theme to source control. Immediately committing to source control ensures a full history of theme customizations are captured in source control.
1. In Visual Studio, add the custom theme to the project so that it appears in the IDE.

### Step 2: Configure Style Transpilation

Many Znode styles are written in SASS to allow global variable definitions to be shared and leverage other features of SASS. The broswer only understands CSS though, so the Visual Studio solution must be configured to transpile *.scss files to *.css files.

OPTIONAL PART: Visual Studio may or may not have a built-in ability to transpile *.scss to *.css files, depending on the installation. If needed, the following compiler plugin can be used.

1. Install the [Visual Studio Web Compiler Plugin](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.WebCompiler) if not already done.
1. In Visual Studio, right click on the [compilerconfig.json](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Projects/Znode.Engine.WebStore/compilerconfig.json) file and go to the “Web Compiler” submenu, check the “Enable Compile on Build…” option.

MANDATORY PART: Visual Studio must be told which file is the root file from which to build the tree of files to transpile.

1. Edit the [compilerconfig.json](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Projects/Znode.Engine.WebStore/compilerconfig.json) file to tell the plugin how to transpile *.scss syles to *.css styles.
1. Replace '`Default`' with the custom theme's folder name.

The [compilerconfig.json](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Projects/Znode.Engine.WebStore/compilerconfig.json), before updating:

```json
  {
    "outputFile": "Views/Themes/Default/Content/css/site.css",
    "inputFile": "Views/Themes/Default/Content/sass/site.scss"
  }
```

The [compilerconfig.json](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Projects/Znode.Engine.WebStore/compilerconfig.json), after updating:

```json
  {
    "outputFile": "Views/Themes/NewTheme/Content/css/site.css",
    "inputFile": "Views/Themes/NewTheme/Content/sass/site.scss"
  }
```

### Step 3: Register New Theme with Znode

Before enabling the new theme, it must be "registered" in Znode's Admin UI.

1. Create a ZIP file of the contents of the `NewTheme` folder. Note that the “Content”, “DynamicGrid”, etc. folders need to be at the root of the ZIP file.
1. For the next step, Znode must be running, so “Start” the solution in Visual Studio and open the Admin UI (http://localhost:6766 by default).
1. In the Admin UI, go to `CMS` > `Site Themes`.
1. Create a new theme, uploading the ZIP file when prompted.

### Step 4: Enable New Theme

Once the theme is "registered" in the Admin UI, it can be enabled for a store.

1. In the Admin UI, go to `Stores & Reps` > `Stores`.
1. Select your store from the list of stores.
1. Choose `NewTheme` to be the theme associated with the store, and choose the first `site.css` option to be the active CSS file.
1. Publish the store by clicking the globe icon next to the store on the `Stores & Reps` > `Stores` page. This moves the state from the SQL database to the MongoDB database, which means the new theme will become active in the WebStore.
1. Load the WebStore (http://localhost:3288 by default) in a browser tab to verify everything is working.

### Step 5: Edit New Theme

Now that the theme is successfully applied to the store, it is time to confirm that it's possible to edit the theme and see the changes reflected in the UI.

1. In the [_base.scss](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Projects/Znode.Engine.WebStore/Views/Themes/Default/Content/sass/_base.scss) file, change the primary color variable from being red to being another color.
1. Build the solution and run it.
1. Refresh the WebStore in the browser and verify the color change has taken effect.

The [_base.scss](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Projects/Znode.Engine.WebStore/Views/Themes/Default/Content/sass/_base.scss) file, before updating:

```css
$base-color-primary:#cc0000;
```

The [_base.scss](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Projects/Znode.Engine.WebStore/Views/Themes/Default/Content/sass/_base.scss) file, after updating:

```css
$base-color-primary:#0000cc;
```
