using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web;

namespace InvalidModelStateFilterSample.Formatting {

    public class SuppressedRequiredMemberSelector : IRequiredMemberSelector {

        public bool IsRequiredMember(MemberInfo member) {

            return false;
        }
    }
}