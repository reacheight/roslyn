﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Editor.EditorConfigSettings.Data;
using Microsoft.CodeAnalysis.Editor.EditorConfigSettings.Updater;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Options;

namespace Microsoft.CodeAnalysis.Editor.EditorConfigSettings.DataProvider.Whitespace
{
    internal class CommonWhitespaceSettingsProvider : SettingsProviderBase<WhitespaceSetting, OptionUpdater, IOption2, object>
    {
        public CommonWhitespaceSettingsProvider(string fileName, OptionUpdater settingsUpdater, Workspace workspace)
            : base(fileName, settingsUpdater, workspace)
        {
            Update();
        }

        protected override void UpdateOptions(AnalyzerConfigOptions editorConfigOptions, OptionSet visualStudioOptions)
        {
            var defaultOptions = GetDefaultOptions(editorConfigOptions, visualStudioOptions, SettingsUpdater);
            AddRange(defaultOptions);
        }

        private IEnumerable<WhitespaceSetting> GetDefaultOptions(AnalyzerConfigOptions editorConfigOptions, OptionSet visualStudioOptions, OptionUpdater updater)
        {
            yield return WhitespaceSetting.Create(FormattingOptions2.UseTabs, EditorFeaturesResources.Use_Tabs, editorConfigOptions, visualStudioOptions, updater, FileName);
            yield return WhitespaceSetting.Create(FormattingOptions2.TabSize, EditorFeaturesResources.Tab_Size, editorConfigOptions, visualStudioOptions, updater, FileName);
            yield return WhitespaceSetting.Create(FormattingOptions2.IndentationSize, EditorFeaturesResources.Indentation_Size, editorConfigOptions, visualStudioOptions, updater, FileName);
            yield return WhitespaceSetting.Create(FormattingOptions2.NewLine, EditorFeaturesResources.New_Line, editorConfigOptions, visualStudioOptions, updater, FileName);
            yield return WhitespaceSetting.Create(FormattingOptions2.InsertFinalNewLine, EditorFeaturesResources.Insert_Final_Newline, editorConfigOptions, visualStudioOptions, updater, FileName);
        }
    }
}
