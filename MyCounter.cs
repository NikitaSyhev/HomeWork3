using System;

public class MyCounter
{
	public MyCounter()
	{
        int _min = 0, _max = 99999999;
        List<myMeterReader> myBillList = new List<myMeterReader>();
        public myCounter(int _number)
        {
            if (_number >= _min || _number <= _max)
            {
                myMeterReader myMR = new myMeterReader(_number);
                myBillList.Add(myMR);
            }
        }
        public bool addMetric(int _number)
        {
            bool result = false;
            int _lastElement = myBillList.Count;
            if (myBillList[_lastElement - 1].WaterCount <= _number)
            {
                myMeterReader myMR = new myMeterReader(_number);
                myBillList.Add(myMR);
                result = true;
            }
            return result;
        }
        public List<myMeterReader> getValues()
        {
            return myBillList;
        }
    }
}
