using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLUS.Utilities.Application.Common
{
    public static class Resources
    {
        #region "Common"

        public const string EXCEPTION_UNKNOWN = "EXCEPTION_UNKNOWN";
        public const string RESOURCE_NOT_FOUND = "RESOURCE_NOT_FOUND";
        public const string ID_REQUIRED = "ID_REQUIRED";
        public const string TOKEN_INVALID = "TOKEN_INVALID";
        public const string TOKEN_NULL = "UN_AUTHORIZED";
        public const string ACTION_SUCCESS = "SUCCESS";
        #endregion

        #region "Auth"
        public const string USER_NOT_FOUND = "USER_NOT_FOUND";
        public const string USER_ALREADY_EXISTED = "USER_ALREADY_EXISTED";
        public const string USER_WAS_LOCKED = "USER_WAS_LOCKED";
        public const string USER_ADD_SUCCESS = "USER_ADD_SUCCESS";
        public const string USER_UPDATE_SUCCESS = "USER_UPDATE_SUCCESS";
        public const string EMAIL_ALREADY_EXISTED = "EMAIL_ALREADY_EXISTED";
        public const string REFERRALCODE_DOES_NOT_EXIST = "REFERRALCODE_DOES_NOT_EXIST";
        public const string PASSWORD_INCORRECTLY = "PASSWORD_INCORRECTLY";
        public const string LOGIN_SUCCESS = "LOGIN_SUCCESS";
        public const string REGISTER_SUCCESS = "REGISTER_SUCCESS";
        public const string USER_CODE_NOT_NULL = "USER_CODE_NOT_NULL";
        public const string USER_CODE_MINLENGTH = "USER_CODE_MINLENGTH";
        #endregion

        #region "LanguageSetting"
        public const string LANGUAGE_CODE_REQUIRED = "LANGUAGE_CODE_REQUIRED";
        public const string LANGUAGE_CODE_LENGHT = "LANGUAGE_CODE_LENGHT";
        public const string LANGUAGEISOCODE_DOES_NOT_EXIST = "LANGUAGEISOCODE_DOES_NOT_EXIST";
        #endregion

        #region "TranspostGoods"
        public const string TRANSPOST_GOODS_DOES_NOT_EXIST = "TRANSPOST_GOODS_DOES_NOT_EXIST";
        public const string REQUEST_GROUP_DOES_NOT_EXIST = "REQUEST_GROUP_DOES_NOT_EXIST";
        public const string TRANSPOST_GOODS_NOT_AUTH = "TRANSPOST_GOODS_NOT_AUTH";
        #endregion
    }
}
