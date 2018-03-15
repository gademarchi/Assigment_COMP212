using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week00_Delegate
{


    using System;
    using System.ComponentModel;
    namespace EventSample
    {
        using System;
        using System.ComponentModel;
    
   
        public class AlarmEventArgs : EventArgs
        {
            private readonly bool snoozePressed;
            private readonly int nrings;
            private string v;

            public AlarmEventArgs(string v)
            {
                this.v = v;
            }

       
            public AlarmEventArgs(bool snoozePressed, int nrings)
            {
                this.snoozePressed = snoozePressed;
                this.nrings = nrings;
            }

     
            public int NumRings
            {
                get { return nrings; }
            }

        
            public bool SnoozePressed
            {
                get { return snoozePressed; }
            }

        
            public string AlarmText
            {
                get
                {
                    if (snoozePressed)
                    {
                        return ("Wake Up!!! Snooze time is over.");
                    }
                    else
                    {
                        return ("Wake Up!");
                    }
                }
            }

                public string Text { get; internal set; }
            }

        // Delegate declaration.
        //
        public delegate void AlarmEventHandler(object sender, AlarmEventArgs e);


        public class AlarmEventProducer
        {
            private bool snoozePressed = false;
            //private int nrings = 0;
            private bool stop = false;

          
            public bool Stop
            {
                get { return stop; }
                set { stop = value; }
            }

    
            public event AlarmEventHandler Alarm;

            protected virtual void OnAlarm(AlarmEventArgs e)
            {
                    //the following it not needed, it just focuses on the name of the delegate
                    AlarmEventHandler handler = Alarm;

                    //only invoke the handler if it is initialize
                    if (handler != null)
                        handler(this, e);

                }

        
                public void RunAlarm()
            {
                    int count = 1;
                    while (count <= 12)
                    {
                        System.Threading.Thread.Sleep(1000);
                        //this raises the event
                        OnAlarm(new AlarmEventArgs(count++.ToString() + " o'clock"));
                    }

                }
            }

        // The WakeMeUp class that has a method AlarmRang that handles the
        // alarm event.
        //
        public class AlarmEventConsumer
        {
                private string name;

                public  AlarmEventConsumer(string name)
                {
                    this.name = name;
                }


                public void AlarmRang(object sender, AlarmEventArgs e)
                {
                    Console.WriteLine(name + " was called with 1 o'clock " + e.Text);
                }
        }

        // The driver class that hooks up the event handling method of
        // WakeMeUp to the alarm event of an Alarm object using a delegate.
        // In a forms-based application, the driver class is the
        // form.
        //
        public class AlarmDriver
        {
            public static void Main(string[] args)
            {
                //the event source/producer
                AlarmEventProducer producer = new AlarmEventProducer();

                //event listener/consumer
                AlarmEventConsumer naren = new AlarmEventConsumer("Narendra");
                AlarmEventConsumer arben = new AlarmEventConsumer("Arben");
                AlarmEventConsumer ilia = new AlarmEventConsumer("Ilia");

                //wire up the listener
                producer.Alarm += new AlarmEventHandler(naren.AlarmRang);
                producer.Alarm += new AlarmEventHandler(arben.AlarmRang);
                producer.Alarm += new AlarmEventHandler(ilia.AlarmRang);
                //uses an anonymous Consumer object
                producer.Alarm += new AlarmEventHandler(new AlarmEventConsumer("Yin Li").AlarmRang);

                //uses a lambda expression
                producer.Alarm += new AlarmEventHandler((sender, e) => Console.WriteLine("Lamdba expression was called with " + e.Text));

                //start the clock
                producer.RunAlarm();
            }
        }
    }

}
