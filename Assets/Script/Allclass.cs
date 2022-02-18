using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serverinfo

{    
    public string username { get; set; }

    public int numberDailyFollow { get; set; }

    public int numberDailyUnFollow { get; set; }

    public int numberDailyLiked { get; set; }

    public int numberHourlyAction { get; set; }

    public int numberDailycomment { get; set; }

    public int MaximumFollowing { get; set; }   

    public int EndFollowing { get; set; }

    public long FollowersCount { get; set; }

    public long FollowingCount { get; set; }

    public int FollowMaximum { set; get; }

    public int ActionHourly { set; get; }

    public int TimeSpend { get; set; }

    public bool BlockComment { get; set; }

    public bool BlockFollow { get; set; }

    public bool BlockUnFollow { get; set; }

    public bool BlockLike { get; set; }

    public bool servieInfo { get; set; }

    public string Hashtag { get; set; }

    public string info { get; set; }

    public bool _debug { set; get; } = false;

    public int GetLoop { set; get; }

    public DateTime LastDay;

    public DateTime LastHour;

    public DateTime TimelikeBlock { set; get; }

    public DateTime TimeFollowBlock { set; get; }

    public DateTime TimeUnFollowBlock { set; get; }

    public DateTime TimeCommentBlock { set; get; }

    public DateTime Now;

}

public class Blacklistinfo

{

    public string info { set; get; }

    public List<string> name = new List<string>();

}

public class Reportcomment

{

    public bool isleave { set; get; }

    public int howmany { set; get; }

    public int number { set; get; }

}

public class boolserver

{

    public bool service { set; get; } = false;

    public string info { set; get; } = null;

}