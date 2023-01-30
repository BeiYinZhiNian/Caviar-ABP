// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Caviar.Configuration.Ui
{
    public static class UiThemes
    {
        public static List<UiThemeInfo> All { get; }

        static UiThemes()
        {
            All = new List<UiThemeInfo>
            {
                new UiThemeInfo("Red", "red"),
                new UiThemeInfo("Pink", "pink"),
                new UiThemeInfo("Purple", "purple"),
                new UiThemeInfo("Deep Purple", "deep-purple"),
                new UiThemeInfo("Indigo", "indigo"),
                new UiThemeInfo("Blue", "blue"),
                new UiThemeInfo("Light Blue", "light-blue"),
                new UiThemeInfo("Cyan", "cyan"),
                new UiThemeInfo("Teal", "teal"),
                new UiThemeInfo("Green", "green"),
                new UiThemeInfo("Light Green", "light-green"),
                new UiThemeInfo("Lime", "lime"),
                new UiThemeInfo("Yellow", "yellow"),
                new UiThemeInfo("Amber", "amber"),
                new UiThemeInfo("Orange", "orange"),
                new UiThemeInfo("Deep Orange", "deep-orange"),
                new UiThemeInfo("Brown", "brown"),
                new UiThemeInfo("Grey", "grey"),
                new UiThemeInfo("Blue Grey", "blue-grey"),
                new UiThemeInfo("Black", "black")
            };
        }
    }
}
