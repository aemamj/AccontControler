using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.Networking;

public class Allfanction : MonoBehaviour {

    public serverinfo serverinfo = new serverinfo();
    public Text numberDailyFollow, numberDailyUnFollow, numberDailyLiked, numberHourlyAction, numberDailycomment, MaximumFollowing, FollowersCount, FollowingCount, FollowMaximum, ActionHourly, TimeSpend, BlockComment, BlockFollow, BlockUnFollow, BlockLike, servieInfo, Hashtag , debug, LastHour, LastDay, TimelikeBlock, TimeFollowBlock, TimeUnFollowBlock, TimeCommentBlock, Now;
    public Text InfoBacklist , InfoWhitelist , InfoHashtag, infoSetvalue, infoComment , GetLoop , EndFollowing , InfoService;
    public InputField _FollowMaximum, _MaxFollower, _GetLoop, _dailygetunfollow, _endfollowing, _ActionHourly, _DailyGetfollower, _DailyGetLike, _DailyGetcomment, _TimeSpan, _MaximumFollowing, _blacklist, _Whitelist;
    public Toggle _Dlog, _EDlog, _debug, _isleave, SetMassage, SetHashtag, ShowHashtag ;
    public InputField _number, _howmany , _hashtag;
    public Text TxtwaittimeCommentBlock_result, TxtwaittimelikeBlock_result, TxtwaittimeunfollowBlock_result, TxtwaittimefollowBlock_result;
    public GameObject waittimeCommentBlock, waittimelikeBlock, waittimeunfollowBlock, waittimefollowBlock;

    string _nameaccont;

    public GameObject Instagram, Twitter, _mainmenu;

    public void changeaccont(int _numberUser)
    {
        switch (_numberUser)
        {
            case 1:
                _nameaccont = "andishevaran.web";
                StartCoroutine(Getinfo());
                break;
            case 2:
                _nameaccont = "reporter.girly";
                StartCoroutine(Getinfo());
                break;
            case 3:
                _nameaccont = "dani.coran";
                StartCoroutine(Getinfo());
                break;
            case 4:
                _nameaccont = "gamer.sexygirl";
                StartCoroutine(Getinfo());
                break;
            case 5:
                Instagram.SetActive(false);
                Twitter.SetActive(true);

                break;
            default:
                _nameaccont = "andishevaran.web";
                StartCoroutine(Getinfo());
                break;
        }
    }

    IEnumerator Getinfo()
    {
        string url = "http://147.135.234.166:5050/api/getvalues/like?" + $"&username="+ _nameaccont;
        Debug.Log(url);
        serverinfo = null;
        using (WWW getinfo = new WWW(url))
        {
            yield return getinfo;

            if (getinfo.error == null)
            {

                serverinfo = JsonConvert.DeserializeObject<serverinfo>(getinfo.text);
                ShowInfo();
            }
            else
            {
                Debug.Log("ERROR: " + getinfo.error);
            }

            Debug.Log(getinfo.text);       

           
        }
    }
    void ShowInfo()
    {
        if (serverinfo != null)
        {
            numberDailyFollow.text = serverinfo.numberDailyFollow.ToString();
            numberDailyUnFollow.text = serverinfo.numberDailyUnFollow.ToString();
            numberDailyLiked.text = serverinfo.numberDailyLiked.ToString();
            numberHourlyAction.text = serverinfo.numberHourlyAction.ToString();
            numberDailycomment.text = serverinfo.numberDailycomment.ToString();
            MaximumFollowing.text = serverinfo.MaximumFollowing.ToString();
            FollowersCount.text = serverinfo.FollowersCount.ToString();
            FollowingCount.text = serverinfo.FollowingCount.ToString();
            FollowMaximum.text = serverinfo.FollowMaximum.ToString();
            ActionHourly.text = serverinfo.ActionHourly.ToString();
            TimeSpend.text = serverinfo.TimeSpend.ToString();
            BlockComment.text = serverinfo.BlockComment.ToString();
            BlockFollow.text = serverinfo.BlockFollow.ToString();
            BlockUnFollow.text = serverinfo.BlockUnFollow.ToString();
            BlockLike.text = serverinfo.BlockLike.ToString();
            servieInfo.text = serverinfo.servieInfo.ToString();
            Hashtag.text = serverinfo.Hashtag.ToString();
            debug.text = serverinfo._debug.ToString();
            LastHour.text = serverinfo.LastHour.ToString("H:mm");
            LastDay.text = serverinfo.LastDay.ToString("dd H:mm");
            TimelikeBlock.text = serverinfo.TimelikeBlock.ToString("MM/dd H:mm");
            TimeFollowBlock.text = serverinfo.TimeFollowBlock.ToString("MM/dd H:mm");
            TimeUnFollowBlock.text = serverinfo.TimeUnFollowBlock.ToString("MM/dd H:mm");
            TimeCommentBlock.text = serverinfo.TimeCommentBlock.ToString("MM/dd H:mm");
            Now.text = serverinfo.Now.ToString("yy/MM/dd H:mm");

            waittimeCommentBlock.SetActive(serverinfo.BlockComment);
            if ((int)(2881 - timecalulate(serverinfo.Now, serverinfo.TimeCommentBlock).TotalMinutes) > 0)
                TxtwaittimeCommentBlock_result.text = ((int)(2881 - timecalulate(serverinfo.Now, serverinfo.TimeCommentBlock).TotalMinutes)).ToString();
            Debug.Log((int)(2881 - timecalulate(serverinfo.Now, serverinfo.TimeCommentBlock).TotalMinutes));

            waittimefollowBlock.SetActive(serverinfo.BlockFollow);
            if ((int)(2881 - timecalulate(serverinfo.Now, serverinfo.TimeFollowBlock).TotalMinutes) > 0)
                TxtwaittimefollowBlock_result.text = ((int)(2881 - timecalulate(serverinfo.Now, serverinfo.TimeFollowBlock).TotalMinutes)).ToString();
            Debug.Log((int)(2881 - timecalulate(serverinfo.Now, serverinfo.TimeFollowBlock).TotalMinutes));

            waittimeunfollowBlock.SetActive(serverinfo.BlockUnFollow);
            if ((int)(2881 - timecalulate(serverinfo.Now, serverinfo.TimeUnFollowBlock).TotalMinutes) > 0)
                TxtwaittimeunfollowBlock_result.text = ((int)(2881 - timecalulate(serverinfo.Now, serverinfo.TimeUnFollowBlock).TotalMinutes)).ToString();
            Debug.Log((int)(2881 - timecalulate(serverinfo.Now, serverinfo.TimeUnFollowBlock).TotalMinutes));

            waittimelikeBlock.SetActive(serverinfo.BlockLike);
            if ((int)(2881 - timecalulate(serverinfo.Now, serverinfo.TimelikeBlock).TotalMinutes) > 0)
                TxtwaittimelikeBlock_result.text = ((int)(2881 - timecalulate(serverinfo.Now, serverinfo.TimelikeBlock).TotalMinutes)).ToString();
            Debug.Log((int)(2881 - timecalulate(serverinfo.Now, serverinfo.TimelikeBlock).TotalMinutes));

            GetLoop.text = serverinfo.GetLoop.ToString();
            EndFollowing.text = serverinfo.EndFollowing.ToString();

            Debug.Log(serverinfo.numberHourlyAction/4);
        }
    }

    public void Back()
    {
        StartCoroutine(Getinfo());
    }
    public void Send()
    {
        StartCoroutine(Setvalues());
    }
    IEnumerator Setvalues()
    {
        string url = "";
        string Commond = "&set=true";
        if (_MaxFollower.text != "0")
            Commond += $"&maxfollower=" + _MaxFollower.text;
        if (_MaxFollower.text != "0")
            Commond += $"&endfollowing=" + _endfollowing.text;
        if (_ActionHourly.text != "0")
            Commond += $"&actionhourly=" + _ActionHourly.text;
        if (_FollowMaximum.text != "0")
            Commond += $"&followmaximum=" + _FollowMaximum.text;
        if (_DailyGetfollower.text != "0") 
             Commond += $"&dailygetfollower=" + _DailyGetfollower.text;
        if (_DailyGetLike.text != "0") 
            Commond += $"&dailygetlike=" + _DailyGetLike.text;
        if (_DailyGetcomment.text != "0")
            Commond += $"&dailygetcomment=" + _DailyGetcomment.text;
        if (_DailyGetcomment.text != "0")
            Commond += $"&dailygetunfollow=" + _dailygetunfollow.text;
        if (_TimeSpan.text != "0")
            Commond += $"&timespend=" + _TimeSpan.text;
        if (_MaximumFollowing.text != "0")
            Commond += $"&maximumfollowing=" + _MaximumFollowing.text;
        if (_GetLoop.text != "0")
            Commond += $"&getloop=" + _GetLoop.text;
        if (_Dlog.isOn)
            Commond += $"&dlog=true";
        if (_EDlog.isOn)
            Commond += $"&edlog=true";
        Commond += $"&debug=" + _debug.isOn;

        url = "http://147.135.234.166:5050/api/setvalues/like?" + $"username="+ _nameaccont + Commond;
        Debug.Log(url);
        using (WWW getinfo = new WWW(url))
        {
            yield return getinfo;

            if (getinfo.error == null)
            {

                infoSetvalue.text = getinfo.text.ToString();
            }
            else
            {
                Debug.Log("ERROR: " + getinfo.error);
            }

            //Debug.Log(getinfo.text);


        }
    }

    public void ABackList()
    {
        StartCoroutine(AddBlacklist());
    }
    public void RBackList()
    {
        StartCoroutine(RemoveBlacklist());
    }
    IEnumerator AddBlacklist()
    {
        string url = "";
        string Commond = "";
        if (_blacklist.text != "")
            Commond += $"&add="+ _blacklist.text;

        url = "http://147.135.234.166:5050/api/blacklist/like?" + $"username="+ _nameaccont + Commond;
        Debug.Log(url);
        using (WWW getinfo = new WWW(url))
        {
            yield return getinfo;
            Blacklistinfo info = new Blacklistinfo();

            if (getinfo.error == null)
            {
                info = JsonConvert.DeserializeObject<Blacklistinfo>(getinfo.text);
                InfoBacklist.text = info.info;
            }
            else
            {
                Debug.Log("ERROR: " + getinfo.error);
            }
        }
    }
    IEnumerator RemoveBlacklist()
    {
        string url = "";
        string Commond = "";
        if (_blacklist.text != "")
            Commond += $"&remove="+ _blacklist.text;

        url = "http://147.135.234.166:5050/api/blacklist/like?" + $"username="+ _nameaccont + Commond;
        Debug.Log(url);
        using (WWW getinfo = new WWW(url))
        {
            yield return getinfo;
            Blacklistinfo info = new Blacklistinfo();

            if (getinfo.error == null)
            {
                info = JsonConvert.DeserializeObject<Blacklistinfo>(getinfo.text);
                InfoBacklist.text = info.info;
            }
            else
            {
                Debug.Log("ERROR: " + getinfo.error);
            }
        }
    }


    public void AWhitList()
    {
        StartCoroutine(AddWhitList());
    }
    public void RWhitList()
    {
        StartCoroutine(RemoveWhitList());
    }
    IEnumerator AddWhitList()
    {
        string url = "";
        string Commond = "";
        if (_Whitelist.text != "")
            Commond += $"&add="+ _Whitelist.text;

        url = "http://147.135.234.166:5050/api/whitelist/like?" + $"username="+ _nameaccont + Commond;
        Debug.Log(url);
        using (WWW getinfo = new WWW(url))
        {
            yield return getinfo;
            Blacklistinfo info = new Blacklistinfo();
            if (getinfo.error == null)
            {
                info = JsonConvert.DeserializeObject<Blacklistinfo>(getinfo.text);
                InfoWhitelist.text = info.info;
            }
            else
            {
                Debug.Log("ERROR: " + getinfo.error);
            }
        }
    }
    IEnumerator RemoveWhitList()
    {
        string url = "";
        string Commond = "";
        if (_Whitelist.text != "")
            Commond += $"&remove="+_Whitelist.text;

        url = "http://147.135.234.166:5050/api/whitelist/like?" + $"username="+ _nameaccont + Commond;
        Debug.Log(url);
        using (WWW getinfo = new WWW(url))
        {
            yield return getinfo;
            Blacklistinfo info = new Blacklistinfo();
            if (getinfo.error == null)
            {
                info = JsonConvert.DeserializeObject<Blacklistinfo>(getinfo.text);
                InfoWhitelist.text = info.info;
            }
            else
            {
                Debug.Log("ERROR: " + getinfo.error);
            }
        }
    }



    public void commmenting()
    {
        StartCoroutine(GetComment());
    }
    IEnumerator GetComment()
    {
        string url = "";
        string Commond = "";
            Commond += $"&isleave="+ _isleave.isOn;
        if (_number.text != "0")
            Commond += $"&number="+ _number.text;
        if (_howmany.text != "0")
            Commond += $"&howmany="+ _howmany.text;

        url = "http://147.135.234.166:5050/api/comment/like?" + $"username="+_nameaccont+"&set="+ SetMassage.isOn + Commond;
        Debug.Log(url);
        using (WWW getinfo = new WWW(url))
        {
            yield return getinfo;
            Reportcomment info = new Reportcomment();
            if (getinfo.error == null)
            {
                info = JsonConvert.DeserializeObject<Reportcomment>(getinfo.text);

                infoComment.text = "Howmany : " + info.howmany + Environment.NewLine;
                infoComment.text += "Number : " + info.number + Environment.NewLine;
                infoComment.text += "Isleave : " + info.isleave + Environment.NewLine;

            }
            else
            {
                Debug.Log("ERROR: " + getinfo.error);
            }
        }
    }



    public void Sethashtag()
    {
        StartCoroutine(hashtag());
    }
    IEnumerator hashtag()
    {
        string url = "";
        string Commond = "";
        if (_hashtag.text != "0")
            Commond += $"&_numhashtag="+ _hashtag.text;

        url = "http://147.135.234.166:5050/api/hastag/like?" + $"username="+_nameaccont+"&set="+ SetHashtag.isOn+ Commond;
        Debug.Log(url);
        using (WWW getinfo = new WWW(url))
        {
            yield return getinfo;

            if (getinfo.error == null)
            {
                InfoHashtag.text = getinfo.text;

            }
            else
            {
                Debug.Log("ERROR: " + getinfo.error);
            }
        }
    }


    public void Show_hashtag()
    {
        StartCoroutine(Showhashtag());
    }
    IEnumerator Showhashtag()
    {
        string url = "";
        string Commond = "";
        if (ShowHashtag.isOn)
            Commond += $"&show="+ ShowHashtag.isOn;

        url = "http://147.135.234.166:5050/api/hastag/like?" + $"username="+_nameaccont + Commond;
        Debug.Log(url);
        using (WWW getinfo = new WWW(url))
        {
            yield return getinfo;
            if (getinfo.error == null)
            {
                InfoHashtag.text = getinfo.text;


            }
            else
            {
                Debug.Log("ERROR: " + getinfo.error);
            }
        }
    }

    public void setservice(bool _service)
    {
        StartCoroutine(Setservice(_service));
    }
    IEnumerator Setservice(bool _flag)
    {
        string url = "";
        string Commond = "";
        Commond += $"&service=" + _flag;

        boolserver infoserver = new boolserver();

        url = "http://147.135.234.166:5050/api/service/like?" + $"username=" + _nameaccont + Commond;
        Debug.Log(url);
        using (WWW getinfo = new WWW(url))
        {
            yield return getinfo;
            if (getinfo.error == null)
            {
                InfoHashtag.text = getinfo.text;
                infoserver = JsonConvert.DeserializeObject<boolserver>(getinfo.text);
                InfoService.text = infoserver.info;
                if (_flag)
                {

                    servieInfo.text += Environment.NewLine+ "Service Start" ;
                }
                else
                    servieInfo.text += Environment.NewLine + "Service Off";
                Debug.Log(getinfo.text.ToString());
            }
            else
            {
                Debug.Log("ERROR: " + getinfo.error);
            }
        }
    }

    public void Save()
    {
        StartCoroutine(_save());
    }
    IEnumerator _save()
    {
        string url = "";
        url = "http://147.135.234.166:5050/api/save/like";
        Debug.Log(url);
        using (WWW getinfo = new WWW(url))
        {
            yield return getinfo;
            if (getinfo.error == null)
            {
                
            }
            else
            {
                Debug.Log("ERROR: " + getinfo.error);
            }
        }
    }


    TimeSpan timecalulate( DateTime Now, DateTime startTime)
    {
        TimeSpan span = Now.Subtract(startTime);
        return span;
    }














}
