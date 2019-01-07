using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingTechnologies.TTAPI;

namespace XTraderCharting
{
    public class TTAPIFunctions : IDisposable
    {
        Form1 MainForm;
        UniversalLoginTTAPI apiInstance;
        UIDispatcher m_disp = null;
        bool m_disposed = false;
        object m_lock = new object();
        string m_username = "KWILSON";
        string m_password = "wt2626wt";

        public void Init(Form1 f, bool sim)
        {
            MainForm = f;
            //Init details
            if (!sim) { m_username = "JHUSCHER"; m_password = "wt2626wt"; }
            //API connection
            m_disp = Dispatcher.AttachUIDispatcher();
            ApiInitializeHandler h = new ApiInitializeHandler(ttApiInitComplete);
            TTAPI.CreateUniversalLoginTTAPI(Dispatcher.Current, m_username, m_password, h);
        }
        public void ttApiInitComplete(TTAPI api, ApiCreationException ex)
        {
            if (ex == null) { apiInstance = (UniversalLoginTTAPI)api; apiInstance.AuthenticationStatusUpdate += new EventHandler<AuthenticationStatusUpdateEventArgs>(apiInstance_AuthenticationStatusUpdate); apiInstance.Start(); }
            else { MainForm.BuildNotification("TT API Initialization Failed: " + ex.Message, false); Dispose(); }
        }
        public void apiInstance_AuthenticationStatusUpdate(object sender, AuthenticationStatusUpdateEventArgs e)
        {
            Contract C = new Contract();
            C.Init(this, MainForm, apiInstance);
            InstrumentLookupSubscription req = new InstrumentLookupSubscription(apiInstance.Session, Dispatcher.Current, new ProductKey("CME", "FUTURE", "HE"), "Feb19");
            req.Update += new EventHandler<InstrumentLookupSubscriptionEventArgs>(C.req_Update);
            req.Start();

            MainForm.XtraderConnected("HE Feb19", C);
        }





        public void Dispose()
        {
            lock (m_lock)
            {
                if (!m_disposed)
                {
                    TTAPI.ShutdownCompleted += new EventHandler(TTAPI_ShutdownCompleted); TTAPI.Shutdown(); m_disposed = true;
                }
            }
        }
        public void TTAPI_ShutdownCompleted(object sender, EventArgs e) { if (m_disp != null) { m_disp.Dispose(); m_disp = null; } apiInstance = null; m_disp = null; m_username = null; m_password = null; GC.SuppressFinalize(this); }
    }
}
