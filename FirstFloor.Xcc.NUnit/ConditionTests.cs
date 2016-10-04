﻿using System.Globalization;
using NUnit.Framework;

namespace FirstFloor.Xcc.NUnit
{
    [TestFixture]
    public class ConditionTests
    {
        [Test]
        public void TestButtonBackgroundWin81()
        {
            TestXaml("WINDOWS_APP",
                "<Button Background=\"Yellow\" win81:Background=\"Green\" wp81:Background=\"Red\" />",
                "<Button Background=\"Green\" />");
        }

        [Test]
        public void TestButtonBackgroundWP81()
        {
            TestXaml("WINDOWS_PHONE_APP",
                "<Button Background=\"Yellow\" win81:Background=\"Green\" wp81:Background=\"Red\" />",
                "<Button Background=\"Red\" />");
        }

        [Test]
        public void TestButtonBackgroundDebug()
        {
            TestXaml("DEBUG",
                "<Button Background=\"Yellow\" win81:Background=\"Green\" wp81:Background=\"Red\" />",
                "<Button Background=\"Yellow\" />");
        }

        [Test]
        public void TestButtonBackgroundRelease()
        {
            TestXaml("!DEBUG",
                "<Button Background=\"Yellow\" win81:Background=\"Green\" wp81:Background=\"Red\" />",
                "<Button Background=\"Yellow\" />");
        }

        [Test]
        public void TestNoUpdates()
        {
            TestXaml("WINDOWS_APP",
                "<Grid><Button /></Grid>",
                "<Grid><Button /></Grid>");
        }
        
        [Test]
        public void TestGridWin81()
        {
            TestXaml("WINDOWS_APP",
                "<win81:Grid />",
                "<Grid />");
        }

        [Test]
        public void TestGridWP81()
        {
            TestXaml("WINDOWS_PHONE_APP",
                "<win81:Grid />",
                "");
        }

        [Test]
        public void TestGridDebug()
        {
            TestXaml("DEBUG",
                "<win81:Grid />",
                "");
        }

        [Test]
        public void TestGridRelease()
        {
            TestXaml("!DEBUG",
                "<win81:Grid />",
                "");
        }

        [Test]
        public void TestGridContentWin81()
        {
            TestXaml("WINDOWS_APP",
                "<win81:Grid><Button /></win81:Grid>",
                "<Grid><Button /></Grid>");
        }

        [Test]
        public void TestGridContentWP81()
        {
            TestXaml("WINDOWS_PHONE_APP",
                "<win81:Grid><Button /></win81:Grid>",
                "");
        }

        [Test]
        public void TestGridContentDebug()
        {
            TestXaml("DEBUG",
                "<win81:Grid><Button /></win81:Grid>",
                "");
        }

        [Test]
        public void TestGridContentRelease()
        {
            TestXaml("!DEBUG",
                "<win81:Grid><Button /></win81:Grid>",
                "");
        }

        [Test]
        public void TestGridsWin81Debug()
        {
            TestXaml("WINDOWS_APP;DEBUG",
                "<win81:Grid x:Name=\"win81\" /><wp81:Grid x:Name=\"wp81\" /><debug:Grid x:Name=\"debug\" /><release:Grid /><Grid />",
                "<Grid x:Name=\"win81\" /><Grid x:Name=\"debug\" /><Grid />");
        }

        [Test]
        public void TestGridsWin81Release()
        {
            TestXaml("WINDOWS_APP;!DEBUG",
                "<win81:Grid x:Name=\"win81\" /><wp81:Grid x:Name=\"wp81\" /><debug:Grid x:Name=\"debug\" /><release:Grid /><Grid />",
                "<Grid x:Name=\"win81\" /><Grid /><Grid />");
        }

        [Test]
        public void TestGridsWP81Debug()
        {
            TestXaml("WINDOWS_PHONE_APP;DEBUG",
                "<win81:Grid x:Name=\"win81\" /><wp81:Grid x:Name=\"wp81\" /><debug:Grid x:Name=\"debug\" /><release:Grid /><Grid />",
                "<Grid x:Name=\"wp81\" /><Grid x:Name=\"debug\" /><Grid />");
        }

        [Test]
        public void TestGridsWP81Release()
        {
            TestXaml("WINDOWS_PHONE_APP;!DEBUG",
                "<win81:Grid x:Name=\"win81\" /><wp81:Grid x:Name=\"wp81\" /><debug:Grid x:Name=\"debug\" /><release:Grid /><Grid />",
                "<Grid x:Name=\"wp81\" /><Grid /><Grid />");
        }

        [Test]
        public void TestNestedWin81Debug()
        {
            TestXaml("WINDOWS_APP;DEBUG",
                "<win81:Grid><debug:Grid><Button /></debug:Grid></win81:Grid>",
                "<Grid><Grid><Button /></Grid></Grid>");
        }

        [Test]
        public void TestNestedWP81Debug()
        {
            TestXaml("WINDOWS_PHONE_APP;DEBUG",
                "<win81:Grid><debug:Grid><Button /></debug:Grid></win81:Grid>",
                "");
        }

        [Test]
        public void TestNestedWin81Release()
        {
            TestXaml("WINDOWS_APP;!DEBUG",
                "<win81:Grid><debug:Grid><Button /></debug:Grid></win81:Grid>",
                "<Grid />");
        }

        [Test]
        public void TestNestedWP81Release()
        {
            TestXaml("WINDOWS_PHONE_APP;!DEBUG",
                "<win81:Grid><debug:Grid><Button /></debug:Grid></win81:Grid>",
                "");
        }

        [Test]
        public void TestNestedAttributeWin81Debug()
        {
            TestXaml("WINDOWS_APP;DEBUG",
                "<win81:Grid debug:Visibility=\"Collapsed\" />",
                "<Grid Visibility=\"Collapsed\" />");
        }

        [Test]
        public void TestNestedAttributeWP81Debug()
        {
            TestXaml("WINDOWS_PHONE_APP;DEBUG",
                "<win81:Grid debug:Visibility=\"Collapsed\" />",
                "");
        }

        [Test]
        public void TestNestedAttributeWin81Release()
        {
            TestXaml("WINDOWS_APP;!DEBUG",
                "<win81:Grid debug:Visibility=\"Collapsed\" />",
                "<Grid />");
        }

        [Test]
        public void TestNestedAttributeWP81Release()
        {
            TestXaml("WINDOWS_PHONE_APP;DEBUG",
                "<win81:Grid debug:Visibility=\"Collapsed\" />",
                "");
        }
        [Test]
        public void TestAdControlWin81Debug()
        {
            TestXaml("WINDOWS_APP;DEBUG",
                @"
<win81:Grid>
  <AdControl xmlns=""using:Microsoft.Advertising.WinRT.UI""/>
</win81:Grid>
<wp81:Grid>
  <AdControl xmlns=""using:Microsoft.Advertising.Mobile.UI""/>
</wp81:Grid>",
                @"
<Grid>
  <AdControl xmlns=""using:Microsoft.Advertising.WinRT.UI"" />
</Grid>
");
        }

        [Test]
        public void TestAdControlWP81Debug()
        {
            TestXaml("WINDOWS_PHONE_APP;DEBUG",
                @"
<win81:Grid>
  <AdControl xmlns=""using:Microsoft.Advertising.WinRT.UI""/>
</win81:Grid>
<wp81:Grid>
  <AdControl xmlns=""using:Microsoft.Advertising.Mobile.UI""/>
</wp81:Grid>",
                @"



<Grid>
  <AdControl xmlns=""using:Microsoft.Advertising.Mobile.UI"" />
</Grid>");
        }

        private static void TestXaml(string symbols, string xamlSnippet, string expectedResult)
        {
            var preprocessor = new XamlPreprocessor(symbols, false);
            var xaml = CreateInputXamlPage(xamlSnippet);
            var result = preprocessor.ProcessXaml(xaml);

            Assert.AreEqual(CreateResultXamlPage(expectedResult), result);
        }

        private static string CreateInputXamlPage(string snippet)
        {
            return string.Format(CultureInfo.InvariantCulture, @"
<Page xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"" xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006"" xmlns:debug=""condition:DEBUG"" xmlns:release=""condition:!DEBUG"" xmlns:win81=""condition:WINDOWS_APP"" xmlns:wp81=""condition:WINDOWS_PHONE_APP"" mc:Ignorable=""debug release win81 wp81"" mc:ProcessContent=""debug:* release:* win81:* wp81:*"">
{0}
</Page>
", snippet);
        }

        private static string CreateResultXamlPage(string snippet)
        {
            return string.Format(CultureInfo.InvariantCulture, @"
<Page xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"" xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006"">
{0}
</Page>
", snippet);
        }
    }
}
