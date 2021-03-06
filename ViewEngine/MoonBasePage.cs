﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;

namespace Moon.Mvc 
{
    public class MoonBasePage : Page
    {
        public object _Model
        {
            get;
            set;
        }

        Type _TType;
        public virtual void SetModel(object model)
        {
            _Model = model;
            if (model != null)
            {
                _TType = model.GetType();
                MHtml = new MoonBasePage.HtmlHelper(model);
            }
        }
        public virtual T Model<T>()
        {
            if (_TType != typeof(T))
            {
                throw new Exception("model的实际类型和你自定不一致,Model实际类型为:" + _TType.FullName);
            }
            return (T)_Model;
        }
        protected Dictionary<string, object> _ViewData = new Dictionary<string, object>();
        /// <summary>
        /// 视图数据字典
        /// </summary>
        public Dictionary<string, object> ViewData
        {
            get
            {
                return _ViewData;
            }
            set
            {
                _ViewData = value;
            }
        }
        public HtmlHelper MHtml
        {
            get;
            set;
        }
        public string CurrentRootUrl
        {
            get
            {
                var baseURL = Request.Url.Scheme + "://" + Request.Url.Authority;
                return baseURL;
            }
        }
        public class HtmlHelper
        {
            public HtmlHelper(object model)
            {
                _model = model;
                _type = _model.GetType();
            }
            object _model;
            Type _type;

            public string TextBoxFor(object value, string propertyName)
            {
                return TextBoxFor(value, propertyName, string.Empty, true);

            }
            public string SubmitTo<T>(string actionName, string domID, string successDo, string errorDo)
                 where T : BaseController
            {

                return SubmitTo<T>(actionName, string.Empty, domID, successDo, errorDo);
            }
            public string SubmitTo<T>(string actionName, string parametersStr, string domID, string successDo, string errorDo)
                where T : BaseController
            {
                string url = UrlUtil.Action<T>(actionName);
                if (string.IsNullOrEmpty(successDo))
                {
                    successDo = string.Empty;
                }
                if (string.IsNullOrEmpty(errorDo))
                {
                    errorDo = string.Empty;
                }
                if (string.IsNullOrEmpty(parametersStr) == false)
                {
                    url += "?" + parametersStr;
                }
                successDo = System.Web.HttpUtility.HtmlEncode(successDo);
                errorDo = System.Web.HttpUtility.HtmlEncode(errorDo);
                const string html = " MAjax='{0}' MUrl='{1}' MSuccessDo='{2}' ErrorDo='{3}' ";
                string ret = string.Format(html, domID, url, successDo, errorDo);
                return ret;
            }

            public string TextBoxFor(object value, string propertyName, string otherInfo, bool showID)
            {
                const string inputBox_showID = "<input type='text' id='{0}' name='{1}'  mfield='{1}' value='{2}' {3} />";
                const string inputBox = "<input type='text'   name='{0}'  mfield='{0}' value='{1}' {2} />";
                var property = _type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                {
                    throw new Exception(_type.FullName + ",没有名为" + propertyName + "的属性");
                }
                propertyName = _type.Name + "." + propertyName;
                if (value == null)
                {
                    value = "";
                }
                string rvalue = System.Web.HttpUtility.HtmlEncode(value.ToString());
                if (otherInfo == null)
                {
                    otherInfo = string.Empty;
                }
                string ret = null;
                if (showID)
                {
                    ret = string.Format(inputBox_showID, propertyName, propertyName, rvalue, otherInfo);
                }
                else
                {
                    ret = string.Format(inputBox, propertyName, rvalue, otherInfo);
                }
                return ret;
            }
            public string PasswordFor(object value, string propertyName)
            {
                return PasswordFor(value, propertyName, string.Empty, true);
            }
            public string PasswordFor(object value, string propertyName, string otherInfo, bool showID)
            {
                const string inputBox_showID = "<input type='password' id='{0}' name='{1}'  mfield='{1}' value='{2}' {3} />";
                const string inputBox = "<input type='password'   name='{0}'  mfield='{0}' value='{1}' {2} />";
                var property = _type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                {
                    throw new Exception(_type.FullName + ",没有名为" + propertyName + "的属性");
                }
                propertyName = _type.Name + "." + propertyName;
                if (value == null)
                {
                    value = "";
                }
                string rvalue = System.Web.HttpUtility.HtmlEncode(value.ToString());
                if (otherInfo == null)
                {
                    otherInfo = string.Empty;
                }
                string ret = null;
                if (showID)
                {
                    ret = string.Format(inputBox_showID, propertyName, propertyName, rvalue, otherInfo);
                }
                else
                {
                    ret = string.Format(inputBox, propertyName, rvalue, otherInfo);
                }
                return ret;
            }
            public string HiddenFor(object value, string propertyName)
            {
                return HiddenFor(value, propertyName, string.Empty, true);
            }
            public string HiddenFor(object value, string propertyName, string otherInfo, bool showID)
            {
                const string inputBox_showID = "<input type='hidden' id='{0}' name='{1}'  mfield='{1}'  value='{2}' {3} />";
                const string inputBox = "<input type='hidden'  name='{0}'  mfield='{0}'  value='{1}' {2} />";
                var property = _type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                {
                    throw new Exception(_type.FullName + ",没有名为" + propertyName + "的属性");
                }
                propertyName = _type.Name + "." + propertyName;
                if (value == null)
                {
                    value = "";
                }
                string rvalue = System.Web.HttpUtility.HtmlEncode(value.ToString());
                if (otherInfo == null)
                {
                    otherInfo = string.Empty;
                }
                string ret = null;
                if (showID)
                {
                    ret = string.Format(inputBox_showID, propertyName, propertyName, rvalue, otherInfo);
                }
                else
                {
                    ret = string.Format(inputBox, propertyName, rvalue, otherInfo);
                }
                return ret;
            }
            public string LableFor(string lable, string propertyName)
            {
                return LableFor(lable, propertyName, string.Empty);
            }
            public string LableFor(string lable, string propertyName, string otherInfo)
            {
                const string labelHtml = "<label for='{0}' {2} >{1}</label>";
                var property = _type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                {
                    throw new Exception(_type.FullName + ",没有名为" + propertyName + "的属性");
                }
                propertyName = _type.Name + "." + propertyName;
                if (otherInfo == null)
                {
                    otherInfo = string.Empty;
                }
                string ret = string.Format(labelHtml, propertyName, lable, otherInfo);
                return ret;
            }
            public string TextAreaFor(object value, string propertyName)
            {
                const string textarea = "<textarea id='{0}' name='{1}' mfield='{1}' >{2}</textarea>";
                var property = _type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                {
                    throw new Exception(_type.FullName + ",没有名为" + propertyName + "的属性");
                }
                propertyName = _type.Name + "." + propertyName;
                string ret = string.Format(textarea, propertyName, propertyName, value);
                return ret;
            }
            public string TextAreaFor(object value, string propertyName, string otherInfo, bool showID)
            {
                const string textarea_showID = "<textarea id='{0}' name='{1}'  mfield='{1}'  {3} >{2}</textarea>";
                const string textarea = "<textarea    name='{0}'  mfield='{0}' {2} >{1}</textarea>";
                var property = _type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                {
                    throw new Exception(_type.FullName + ",没有名为" + propertyName + "的属性");
                }
                propertyName = _type.Name + "." + propertyName;
                if (otherInfo == null)
                {
                    otherInfo = string.Empty;
                }
                string ret = null;
                if (showID)
                {
                    ret = string.Format(textarea_showID, propertyName, propertyName, value, otherInfo);
                }
                else
                {
                    ret = string.Format(textarea, propertyName, value, otherInfo);
                }
                return ret;
            }
            public string RadioGroupFor(int value, string propertyName, Type enumType)
            {
                var property = _type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                {
                    throw new Exception(_type.FullName + ",没有名为" + propertyName + "的属性");
                }

                propertyName = _type.Name + "." + propertyName;
                StringBuilder sb = new StringBuilder();
                const string tempRadio = "<input type='radio' name='{0}'  mfield='{0}' id='{1}'   value='{2}'   />";
                const string tempRadioChk = "<input type='radio' name='{0}'  mfield='{0}'  id='{1}'   value='{2}' checked='checked'  />";
                const string tempLable = "<label for='{0}'>{1}</label>";
                var dic = Moon.Orm.EnumDescriptionAttribute.GetEnumAllDescriptions(enumType);
                foreach (var kvp in dic)
                {
                    if (kvp.Key != value)
                    {
                        string r = string.Format(tempRadio, propertyName, propertyName + kvp.Key, kvp.Key);
                        sb.AppendLine(r);
                    }
                    else
                    {
                        string r = string.Format(tempRadioChk, propertyName, propertyName + kvp.Key, kvp.Key);
                        sb.AppendLine(r);
                    }
                    sb.AppendLine(string.Format(tempLable, propertyName + kvp.Key, kvp.Value));
                }
                return sb.ToString();
            }
            public string CheckBoxFor(bool value, string propertyName)
            {
                return CheckBoxFor(value, propertyName, string.Empty, true);
            }
            public string CheckBoxFor(bool value, string propertyName, string otherInfo, bool showID)
            {
                var property = _type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                {
                    throw new Exception(_type.FullName + ",没有名为" + propertyName + "的属性");
                }
                propertyName = _type.Name + "." + propertyName;
                const string inputBox_UseID = "<input type='checkbox' id='{0}' name='{1}'  mfield='{1}'  {2} {3} />";
                const string inputBox = "<input type='checkbox'  name='{0}'  mfield='{0}' {1} {2} />";
                string checkedHtml = " ";
                if (value)
                {
                    checkedHtml = " checked='checked' ";
                }
                if (otherInfo == null)
                {
                    otherInfo = "";
                }
                string ret = null;
                if (showID)
                {
                    ret = string.Format(inputBox_UseID, propertyName, propertyName, checkedHtml, otherInfo);
                }
                else
                {
                    ret = string.Format(inputBox, propertyName, checkedHtml, otherInfo);
                }
                return ret;
            }

            public string NameValue(object mFieldValue, string propertyName)
            {
                var property = _type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                {
                    throw new Exception(_type.FullName + ",没有名为" + propertyName + "的属性");
                }
                string ret = " name=\"{0}\" value=\"{1}\" ";
                ret = string.Format(ret, propertyName, mFieldValue);
                return ret;
            }

            public string CNameValue(object mFieldValue, string propertyName)
            {
                var property = _type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                {
                    throw new Exception(_type.FullName + ",没有名为" + propertyName + "的属性");
                }
                propertyName = _type.Name + "." + propertyName;
                string ret = " name=\"{0}\" value=\"{1}\" ";
                ret = string.Format(ret, propertyName, mFieldValue);
                return ret;
            }
            public string Name(string propertyName)
            {
                var property = _type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                {
                    throw new Exception(_type.FullName + ",没有名为" + propertyName + "的属性");
                }
                string ret = " name=\"{0}\"";
                ret = string.Format(ret, propertyName);
                return ret;
            }
            public string NameID(string propertyName)
            {
                var property = _type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                {
                    throw new Exception(_type.FullName + ",没有名为" + propertyName + "的属性");
                }
                string ret = " name=\"{0}\" id=\"{1}\" ";
                ret = string.Format(ret, propertyName, propertyName);
                return ret;
            }

            public string CName(string propertyName)
            {
                var property = _type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                {
                    throw new Exception(_type.FullName + ",没有名为" + propertyName + "的属性");
                }
                propertyName = _type.Name + "." + propertyName;
                string ret = " name=\"{0}\"";
                ret = string.Format(ret, propertyName);
                return ret;
            }

            public string CNameID(string propertyName)
            {
                var property = _type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                {
                    throw new Exception(_type.FullName + ",没有名为" + propertyName + "的属性");
                }
                propertyName = _type.Name + "." + propertyName;
                string ret = " name=\"{0}\" id=\"{1}\" ";
                ret = string.Format(ret, propertyName, propertyName);
                return ret;
            }
        }
    }
}
