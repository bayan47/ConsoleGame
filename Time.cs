

namespace sample1
{
     internal class TimeAction
    {
        long timestamp; //первоначальное время создания экземпляра (исходное)
        long timestamp2; //время последнего шага времени
       internal delegate void Action();

         internal void Operation(long time_step,long time_out, Action action)
         {
            
             if(Program.deltasec< timestamp+time_out || time_out==-1)
             {
                    if (Program.deltasec>=time_step+timestamp2 || timestamp2 == timestamp)
                    
                    {
                        timestamp2 = Program.deltasec;
                        action?.Invoke();
                    }
             }
         }



        internal TimeAction()
         {
            timestamp = Program.deltasec;
            timestamp2 = timestamp;
         }

    }

}