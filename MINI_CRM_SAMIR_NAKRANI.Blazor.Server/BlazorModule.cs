using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.BaseImpl;

using MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Controllers;
using MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Editors.CustomActivityList;
using MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Editors.ViewItems;

using System.ComponentModel;

namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server
{
    [ToolboxItemFilter("Xaf.Platform.Blazor")]
    public sealed class MINI_CRM_SAMIR_NAKRANIBlazorModule : ModuleBase
    {
        public MINI_CRM_SAMIR_NAKRANIBlazorModule()
        {
            DataAccessModeHelper.RegisterEditorSupportedModes(
                typeof(ActivityListEditor),
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
            //application.SetupComplete += Application_SetupComplete;
        }

        private void Application_SetupComplete(object sender, EventArgs e)
        {
            var app = (XafApplication)sender;

            var dashboard = app.Model.Views.AddNode<IModelDashboardView>("AppointmentsScheduler_Dashboard");
            dashboard.Caption = "Calendar";

             dashboard.Items.AddNode<IModelDashboardViewItem>("Scheduler");

            var navigation = app.Model as IModelApplicationNavigationItems;

            var navItem = navigation.NavigationItems.Items.AddNode<IModelNavigationItem>("Calendar");
            navItem.Caption = "Calendar";
            navItem.View = dashboard;
        }
    }
}