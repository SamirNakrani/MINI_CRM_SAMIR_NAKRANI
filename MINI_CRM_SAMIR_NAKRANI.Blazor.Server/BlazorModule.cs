using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.BaseImpl;
using MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Editors.CustomActivityList;
using System.ComponentModel;

namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server
{
    [ToolboxItemFilter("Xaf.Platform.Blazor")]
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
    public sealed class MINI_CRM_SAMIR_NAKRANIBlazorModule : ModuleBase
    {
        public MINI_CRM_SAMIR_NAKRANIBlazorModule()
        {
            DataAccessModeHelper.RegisterEditorSupportedModes(
            typeof(BlazorCustomActivityListEditor),
            new[] { CollectionSourceDataAccessMode.Client }
        );
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            return ModuleUpdater.EmptyModuleUpdaters;
        }
        protected override IEnumerable<Type> GetDeclaredExportedTypes()
        {
            return base.GetDeclaredExportedTypes();
        }
        public override void Setup(XafApplication application)
        {
            base.Setup(application);
        }
    }
}
