
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

using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Org.Json;
using Java.IO;
using Android.Database;
using Android.Provider;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace com.xamarin.example.tabhostwalkthrough
{
	[Activity (Label = "List")]			


public class ExpandableListAdapter : BaseExpandableListAdapter
{
	private readonly Context _context;

	public ExpandableListAdapter(Context context)
	{
		_context = context;
	}

	public override Object GetChild(int groupPosition, int childPosition)
	{
		return null;
	}

	public override long GetChildId(int groupPosition, int childPosition)
	{
		return childPosition;
	}

	public override int GetChildrenCount(int groupPosition)
	{
		return /*return child count for parent in groupPosition position*/;
	}

	public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
	{
		var view = convertView;

		if (view == null)
		{
			var inflater = _context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
			view = inflater.Inflate(Resource.Layout.your_childview, null);
		}

		//setup childview

		return view;
	}

	public override Object GetGroup(int groupPosition)
	{
		return null;
	}

	public override long GetGroupId(int groupPosition)
	{
		return groupPosition;
	}

	public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
	{
		var view = convertView;

		if (view == null)
		{
			var inflater = _context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
			view = inflater.Inflate(Resource.Layout.your_groupview, null);
		}

		//setup groupview

		return view;
	}

	public override bool IsChildSelectable(int groupPosition, int childPosition)
	{
		return true;
	}

	public override int GroupCount
	{
		get { return Dal.Dal.DataAccesser.Schedules.Count; }
	}

	public override bool HasStableIds {
			get { return true; }
		}
	}}