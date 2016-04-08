using UnityEngine;

public static class Bench {
	static System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
	static System.TimeSpan elapsedTime;

	public static string Title(string message)
	{
		string ret = "\n" + new string('#', message.Length) + "\n";
		ret += message + "\n";
		ret += new string('#', message.Length) + "\n";
		Debug.Log(ret);
		return ret;
	}

	public static string Start(string message = "")
	{
		string ret = "";
		if (message.Length != 0) {
			ret = "\n" + message + "\n";
			ret += new string('-', message.Length) + "\n";
			Debug.Log(ret);
		}
		timer.Reset();
		timer.Start();
		return ret;
	}

	public static string End(string message = "")
	{
		timer.Stop();
		elapsedTime = timer.Elapsed;

		string t = System.String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds,
			elapsedTime.Milliseconds / 10);

		string ret = "\n" + message + "   " + t + "\n";
		Debug.Log(ret);
		return ret;
	}
}
