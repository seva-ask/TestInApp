
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace InAppTest
{
	public class MainView : LinearLayout
	{
		public event Action Buy = () => {};

		public MainView(Context context) : base (context)
		{
			Orientation = Orientation.Vertical;

			var buyBtn = new Button(context);
			{
				buyBtn.Text = "Buy item from GP";
				buyBtn.Click += OnBuyBtnClick;
			}
			AddView(buyBtn);
		}

		void OnBuyBtnClick (object sender, EventArgs e)
		{
			Buy.Invoke();
		}
	}
}

