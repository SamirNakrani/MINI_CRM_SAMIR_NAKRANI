using DevExpress.ExpressApp;
using DevExpress.ExpressApp.StateMachine;
using DevExpress.ExpressApp.StateMachine.NonPersistent;
using DevExpress.XtraRichEdit.Import.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects
{
    internal class ProcessStateMachine : StateMachine<Lead>, IStateMachineUISettings
    {

        private IState startState;

        public ProcessStateMachine(IObjectSpace objectSpace) : base(objectSpace)
        {
            startState = new State(this, "Open", ProcessState.Open);
            IState qualified = new State(this, "Qualified", ProcessState.Qualified);
            IState proposed = new State(this, "Propose", ProcessState.Propose);
            IState developed = new State(this, "Develop", ProcessState.Developed);
            IState closed = new State(this, "Closed", ProcessState.Closed);

            startState.Transitions.Add(new Transition(qualified));
            qualified.Transitions.Add(new Transition(developed));
            qualified.Transitions.Add(new Transition(startState));
            developed.Transitions.Add(new Transition(proposed));
            developed.Transitions.Add(new Transition(qualified));
            proposed.Transitions.Add(new Transition(closed));
            proposed.Transitions.Add(new Transition(developed));
            closed.Transitions.Add(new Transition(proposed));

            States.Add(startState);
            States.Add(qualified);
            States.Add(developed);
            States.Add(proposed);
            States.Add(closed);
        }

        public override string Name => "Change Lead Status";
        public override string StatePropertyName => nameof(Lead.State);
        public override IState StartState => startState;

        public bool ExpandActionsInDetailView => false;
    }
}
