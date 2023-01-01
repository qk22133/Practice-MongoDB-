﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSwebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSwebapi.Models.Tests
{     
        public class Member
        {
            public string name { get; set; }
            public string phone { get; set; }
        }
        [TestClass()]
        public class MemberControllerTests
        {
            private List<Member> GetTestMember()
            {
                var testMember = new List<Member>();
                testMember.Add(new Member { name = "測試人員1", phone = "09123456789" });
                testMember.Add(new Member { name = "測試人員2", phone = "09123456788" });
                testMember.Add(new Member { name = "測試人員3", phone = "09123456787" });
                return testMember;
            }
            [TestMethod()]
            public void CreatUserTest()
            {
                var newMember = GetTestMember().First();
                var request = new AddMemberRequest();
                request.uid = new Random().Next().ToString();
                request.name = newMember.name;
                request.phone = newMember.phone;
                var response = new MemberController().Post(request);
                Assert.AreEqual(response.ok, true);
            }
        }
}