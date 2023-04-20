using System;

public class WaterCounter
{
	public WaterCounter()

    enum{
		january = 1, febryary, march, april, may, june, july, august, september,october, november, december, 
    }
    int waterCount;
    public int WaterCount
    {
        get
        {
            return waterCount;
        }
        set
        {
            waterCount = value;
        }
    }
    public myMeterReader(int _number)
    {
        waterCount = _number;
    }
    public string convert2Str()
    {
        string _tmp = waterCount.ToString();
        while (_tmp.Length < 8)
        {
            _tmp = "0" + _tmp;
        }
        return _tmp;
    }
}
struct myMeterReader02
{
    myMeterReader Cold;
    myMeterReader Hot;
}

}
