using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingTechnologies.TTAPI;
using TradingTechnologies.TTAPI.Tradebook;

namespace XTraderCharting
{
    public class Contract
    {
        Form1 MainForm;        TTAPIFunctions TTAPIF;        UniversalLoginTTAPI apiInstance;
        PriceSubscription ps; TimeAndSalesSubscription tsSub;        Instrument Instrument;
        public void Init(TTAPIFunctions conclass, Form1 f, UniversalLoginTTAPI api )        {            MainForm = f; TTAPIF = conclass; apiInstance = api;        }

        public void req_Update(object sender, InstrumentLookupSubscriptionEventArgs e)
        {
            if (e.Instrument != null && e.Error == null)
            {
                ps = new PriceSubscription(e.Instrument, Dispatcher.Current) { Settings = new PriceSubscriptionSettings(PriceSubscriptionType.InsideMarket) }; ps.FieldsUpdated += new FieldsUpdatedEventHandler(ps_FieldsUpdated); ps.Start();
                tsSub = new TimeAndSalesSubscription(e.Instrument, Dispatcher.Current); tsSub.Update += new EventHandler<TimeAndSalesEventArgs>(tsSub_Update); tsSub.Start();
                Instrument = e.Instrument; SetUp();
            }
        }
        void SetUp()
        {

        }



        public double MidPoint = 0;
        public double Low = 0;
        public double High = 0;
        public double Last = 0;
        public double First = 0;

        private void ps_FieldsUpdated(object sender, FieldsUpdatedEventArgs e)
        {
            if (e.Error == null)
            {
                Last = MidPoint;

                double Bid = e.Fields.GetBestBidPriceField().Value.ToTicks();
                double Ask = e.Fields.GetBestAskPriceField().Value.ToTicks();

                MidPoint = ((Ask - Bid) / 2) + Bid;

                if (First == 0 && e.Fields.GetOpenPriceField().HasValidValue) First = e.Fields.GetOpenPriceField().Value.ToTicks();

                if (High == 0) High = MidPoint; if (Low == 0) Low = MidPoint;

                if (MidPoint > High) High = MidPoint; else if (MidPoint < Low) Low = MidPoint;
            }
        }



        public double CSOpen = 0;
        public double CSLow = 0;
        public double CSHigh = 0;
        public double CSClose = 0;

        private void tsSub_Update(object sender, TimeAndSalesEventArgs e)
        {
            foreach (TimeAndSalesData tsData in e.Data)
            {
                Price ltp = tsData.TradePrice;
                Quantity ltq = tsData.TradeQuantity;

                if (CSOpen == 0) CSOpen = ltp.ToTicks();

                if (ltp.ToTicks() > CSHigh) CSHigh = ltp.ToTicks();
                else if (ltp.ToTicks() < CSLow || CSLow == 0) CSLow = ltp.ToTicks();

                CSClose = ltp.ToTicks();
            }
            MainForm.CSInterumData();
        }




    }
}
