using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using System;
using Android.Graphics;
using static Android.Views.View;

namespace RecyclerView_Demo
{
    [Activity(Label = "RecyclerView_Demo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity,MyItemClickListener
    {

        
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        CustomAdapter mAdapter;
        string[] dataSet;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            InitDataSet();
            SetContentView(Resource.Layout.Main);
           
            mLayoutManager = new LinearLayoutManager(this);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            mAdapter = new CustomAdapter(dataSet,this);
            mAdapter.setOnItemClickListener(this);
            mRecyclerView.SetAdapter(mAdapter);

            //mRecyclerView.SetOnTouchListener(this);
        }

        public void InitDataSet()
        {
            dataSet = new string[60];
            for (int i = 0; i < 60; i++)
            {
                dataSet[i] = "This is element #" + i;
            }
        }

        public void OnItemClick(View view, int postion)
        {
            mAdapter.NotifyItemChanged(CustomAdapter.selected_position);
            CustomAdapter.selected_position = postion;
            mAdapter.NotifyItemChanged(postion);
        }

        //public Boolean NextMonth()
        //{
        //    Toast.MakeText(this, "NextMonth called", ToastLength.Long).Show();
        //    return true;
        //}

        //public Boolean PreviousMonth()
        //{
        //    Toast.MakeText(this, "PreviousMonth called", ToastLength.Long).Show();
        //    return true;
        //}

        //public bool OnTouch(View v, MotionEvent e)
        //{
        //    float x1 = 0;
        //    float x2 = 0;
        //    switch (e.Action)
        //    {
        //        case MotionEventActions.Down:
        //            x1 = e.GetX();
        //            break;
        //        case MotionEventActions.Up:
        //            x2 = e.GetX();
        //            float deltaX = x2 - x1;
        //            if (Math.Abs(deltaX) > 5)
        //            {
        //                // Left to Right swipe action
        //                if (x2 > x1)
        //                {
        //                    NextMonth();
        //                }

        //                // Right to left swipe action               
        //                else
        //                {
        //                    PreviousMonth();
        //                }
        //            }


        //            break;
        //    }
        //    return false;
        //}
    }

    
}

