using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using static Android.Views.View;
using Android.Graphics;

namespace RecyclerView_Demo
{
    public class CustomAdapter : RecyclerView.Adapter
    {
        private string[] dataSet;
       private Context MyContext;
        public static int selected_position=0;
        
        MyItemClickListener mItemClickListener;
        public CustomAdapter(string[] dataSet,Context context)
        {
            this.dataSet = dataSet;
            MyContext = context;
        }

        public void setOnItemClickListener(MyItemClickListener listener)
        {
            this.mItemClickListener = listener;
        }
        public override int ItemCount
        {
            get
            {
                return dataSet.Length;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            (holder as MyViewHolder).TextView.SetText(dataSet[position], TextView.BufferType.Normal);
            if (selected_position == position)
            {
                holder.ItemView.SetBackgroundColor(Color.LightGray);
            }
            else
            {
                holder.ItemView.SetBackgroundColor(Color.Transparent);
            }
        }

       

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View v = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.items, parent, false);
            MyViewHolder mvh = new MyViewHolder(v, mItemClickListener,MyContext);
            return mvh;
        }

        
    }

    public class MyViewHolder:RecyclerView.ViewHolder,IOnTouchListener
    {
        private TextView textView;
        private MyItemClickListener mListener;
        private Context myContext;
        float x1 = 0;
        float x2 = 0;
        public TextView TextView { get { return textView; } }
        public MyViewHolder(View v, MyItemClickListener mItemClickListener) : base(v)
        {
            textView = v.FindViewById<TextView>(Resource.Id.itemText);
            mListener = mItemClickListener;
            v.SetOnTouchListener(this);
        }

        public MyViewHolder(View v, MyItemClickListener mItemClickListener, Context myContext) : this(v, mItemClickListener)
        {
            this.myContext = myContext;
        }
        public bool OnTouch(View v, MotionEvent e)
        {
            
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    x1 = e.GetX();
                    if (mListener != null)
                    {
                        mListener.OnItemClick(v, Position);
                    }
                    break;
                case MotionEventActions.Up:
                    x2 = e.GetX();
                    float deltaX = x2 - x1;
                    if (Math.Abs(deltaX) > 5)
                    {
                        // Left to Right swipe action
                        if (x2 > x1)
                        {
                            NextMonth(v);
                        }

                        // Right to left swipe action               
                        else
                        {
                            PreviousMonth(v);
                        }
                    }
                    break;
            }
            return true;           
        }

        public Boolean NextMonth(View v)
        {
            Toast.MakeText(myContext, "NextMonth called", ToastLength.Short).Show();      
            return true;
        }

        public Boolean PreviousMonth(View v)
        {
            Toast.MakeText(myContext, "PreviousMonth called", ToastLength.Short).Show();
            return true;
        }
    }
}