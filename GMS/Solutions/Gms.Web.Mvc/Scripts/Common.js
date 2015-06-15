

$(function () {
    
    //回到顶部
    function BackTop() {
        $('html, body').animate({ scrollTop: 0 }, 500);
    };
    
    //重新加载当前页
    $.fn.reloadPage = function () {
        window.loadpage(this);
    };
    //绑定数据
    $.fn.binddata = function (data, defaultFieldNameSpace) {
        if (!data) return false;
        //绑定数据到页面元素
        //defaultFieldPrefix,如果没有前面的名字则使用默认的名字，如"aa"则成为"name.aa","aa.bb"则不变
        return this.each(function () {
            var self = $(this);
            var field = $(this).attr("datafield") || this.name;

            if (field == undefined || field == null || field == "") return;


            var item = $.getDataByTemplate(data, field, defaultFieldNameSpace);

            if (self.is(':checkbox')) {
                if (item != null && (item == true || item == "1" || item.toString().toLowerCase() == "true")) {
                    self.attr("checked", true);
                } else {
                    self.removeAttr("checked");
                }

            } else if (self.is(':radio')) {
                if (item != null && this.value == item.toString()) {
                    self.attr("checked", true);
                }
            } else if (self.is('select')) {
                var val = item.Id | item;
                var subitem = self.children('option[value="' + val + '"]');
                if (subitem.length == 0) {
                    self.attr('selval', val);
                } else {
                    self.removeAttr('selval').val(val);
                }
            } else {
                if (item != null) {
                    //处理日期数据
                    if (item.getDate) {
                        var str = item.format(self.attr('format') || 'isoDate');
                        if (self.is(':input'))
                            self.val(str);
                        else
                            self.text(str);
                    } else {
                        if (self.is(':input')) {
                            //如果是数组并且定义了数组显示规则
                            if ($.isArray(item) && self.attr('displayfield'))
                                self.bindArray(item);
                            else
                                self.val(item);
                        }
                        else {
                            self.text(item);
                        }
                    }

                } else {
                    self.val('');
                }
            }
            self.change();

        });
    };
    
    $.fn.binddataChecklist = function (data) {
        if (!data) return false;
        //绑定数据到页面元素
        return this.each(function () {
            var self = $(this);
            var field = $(this).attr("datafield") || this.name;

            if (field == undefined || field == null || field == "") return;


            var item = $.getDataByTemplate(data, field);

            if (self.is(':checkbox')) {
                if (item != null && (item == true || item == "1" || item.toString().toLowerCase() == "true")) {
                    self.attr("checked", true);
                } else {
                    self.removeAttr("checked");
                }

                self.change();

            } 
            
            

        });
    };
    
    //序列化元素为json
    $.fn.SerializeElements = function (skipempty) {
        var items = {};
        this.each(function () {
            var fieldname = $(this).attr('datafield') || this.name;
            if (fieldname) {
                var self = $(this);
                if (self.is(':checkbox') || self.is(':radio')) {
                    if (self.attr('checked'))
                        items[fieldname] = $(this).val();
                } else {
                    var val = self.val();
                    if (!self.is(':input')) {
                        val = val || $.trim(self.text());
                    }
                    if (val.length == 0 && skipempty) return;
                    items[fieldname] = val;
                }
            }
        });
        return items;
    };
    

    var dateFormat = function () {
        var token = /d{1,4}|m{1,4}|yy(?:yy)?|([HhMsTt])\1?|[LloSZ]|"[^"]*"|'[^']*'/g,
            timezone = /\b(?:[PMCEA][SDP]T|(?:Pacific|Mountain|Central|Eastern|Atlantic) (?:Standard|Daylight|Prevailing) Time|(?:GMT|UTC)(?:[-+]\d{4})?)\b/g,
            timezoneClip = /[^-+\dA-Z]/g,
            pad = function (val, len) {
                val = String(val);
                len = len || 2;
                while (val.length < len) val = "0" + val;
                return val;
            };

        // Regexes and supporting functions are cached through closure
        return function (date, mask, utc) {
            var dF = dateFormat;

            // You can't provide utc if you skip other args (use the "UTC:" mask prefix)
            if (arguments.length == 1 && Object.prototype.toString.call(date) == "[object String]" && !/\d/.test(date)) {
                mask = date;
                date = undefined;
            }

            // Passing date through Date applies Date.parse, if necessary
            date = date ? new Date(date) : new Date;
            if (isNaN(date)) throw SyntaxError("invalid date");

            mask = String(dF.masks[mask] || mask || dF.masks["default"]);

            // Allow setting the utc argument via the mask
            if (mask.slice(0, 4) == "UTC:") {
                mask = mask.slice(4);
                utc = true;
            }

            var _ = utc ? "getUTC" : "get",
                d = date[_ + "Date"](),
                D = date[_ + "Day"](),
                m = date[_ + "Month"](),
                y = date[_ + "FullYear"](),
                H = date[_ + "Hours"](),
                M = date[_ + "Minutes"](),
                s = date[_ + "Seconds"](),
                L = date[_ + "Milliseconds"](),
                o = utc ? 0 : date.getTimezoneOffset(),
                flags = {
                    d: d,
                    dd: pad(d),
                    ddd: dF.i18n.dayNames[D],
                    dddd: dF.i18n.dayNames[D + 7],
                    m: m + 1,
                    mm: pad(m + 1),
                    mmm: dF.i18n.monthNames[m],
                    mmmm: dF.i18n.monthNames[m + 12],
                    yy: String(y).slice(2),
                    yyyy: y,
                    h: H % 12 || 12,
                    hh: pad(H % 12 || 12),
                    H: H,
                    HH: pad(H),
                    M: M,
                    MM: pad(M),
                    s: s,
                    ss: pad(s),
                    l: pad(L, 3),
                    L: pad(L > 99 ? Math.round(L / 10) : L),
                    t: H < 12 ? "a" : "p",
                    tt: H < 12 ? "am" : "pm",
                    T: H < 12 ? "A" : "P",
                    TT: H < 12 ? "AM" : "PM",
                    Z: utc ? "UTC" : (String(date).match(timezone) || [""]).pop().replace(timezoneClip, ""),
                    o: (o > 0 ? "-" : "+") + pad(Math.floor(Math.abs(o) / 60) * 100 + Math.abs(o) % 60, 4),
                    S: ["th", "st", "nd", "rd"][d % 10 > 3 ? 0 : (d % 100 - d % 10 != 10) * d % 10]
                };

            return mask.replace(token, function ($0) {
                return $0 in flags ? flags[$0] : $0.slice(1, $0.length - 1);
            });
        };
    }();

    // Some common format strings
    dateFormat.masks = {
        "default": "ddd mmm dd yyyy HH:MM:ss",
        shortDate: "m/d/yy",
        midDate: "mm/dd/yyyy",
        mediumDate: "mmm d, yyyy",
        longDate: "mmmm d, yyyy",
        fullDate: "dddd, mmmm d, yyyy",
        shortTime: "h:MM TT",
        mediumTime: "h:MM:ss TT",
        longTime: "h:MM:ss TT Z",
        isoDate: "yyyy-mm-dd",
        isoTime: "HH:MM:ss",
        minute: "yyyy-mm-dd HH:MM",
        isoDateTime: "yyyy-mm-dd HH:MM:ss",
        isoUtcDateTime: "UTC:yyyy-mm-dd HH:MM:ss'Z'"
    };

    // Internationalization strings
    dateFormat.i18n = {
        dayNames: [
            "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat",
            "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
        ],
        monthNames: [
            "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec",
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
        ]
    };

    Date.prototype.format = function (mask, utc) {
        return dateFormat(this, mask, utc);
    };
    Date.prototype.AddDays = function(i) {
        var dt = new Date(this);
        dt.setDate(dt.getDate() + i);
        return dt;
    };

    //格式化
    $.Formater = {
        Default: function (val, rec) {
            return $.getDataByTemplate(rec, this.display || this.field);
        },
        Date: function (dt, rec) {
            return dt.format("isoDate");

        },
        DateTime: function (dt, rec) {
            if (!dt) return "";
           
            return dt.format("isoDateTime",true);
        }//,
        //Edit: function (grd, col, val, rec) {
        //    var id = grd.attr('id');
        //    var strAdd = "";
        //    if (col.editable != false)
        //        strAdd += '<a gid="' + id + '" href="#" class="Edit" plain="true" icon="icon-edit">编辑</a>&nbsp;';
        //    if (grd.attr('del'))
        //        strAdd += '<a gid="' + id + '" href="#" class="Del" plain="true" icon="icon-del">删除</a>&nbsp;';
        //    return strAdd;
        //}

    };
    
    //解析数据模板
    $.getDataByTemplate = function (data, template, defaultFieldNameSpace) {
        var getData = function (data, field) {
            if (defaultFieldNameSpace && field.indexOf(".") <= 0) {
                field = defaultFieldNameSpace + "." + field;
            }
            var item = data;
            var arrFields = field.split(".");
            for (var i = 0; i < arrFields.length; i++) {
                item = item[arrFields[i]];
                if (item == null || item == undefined) {
                    break;
                }
            }
            if (item == undefined) {
                item = null;
            }
            return item;
        };
        var item;
        //替换例如 datafield="部门:{{Department.Name}}"的表达式
        var re = /\{\{([^\}]*)\}\}/g;
        if (re.test(template)) {
            item = template.replace(re, function () {
                return getData(data, arguments[1]) || "";
            });
        } else {
            //简单的替换 datefield="Department.Name"类型的值
            item = getData(data, template);
        }
        return item;
    };

    $.ValidateForm = function () { };

    $.fn.gridform = function(options) {
        if (!$.isPlainObject(options)) {
            return this.formdialog(options);
        }
        var oldsuccess = options.success;
        var oldbefore = options.beforeSubmit;
        options.beforeSubmit = function(arr, $form, opt) {
            var gridopt = options.forgid.datagrid('options');
            if (gridopt.beforeSave) gridopt.beforeSave.call(this, arr, $form, opt, options.data);
            if (oldbefore)
                oldbefore.apply(this, arguments);
        };
        options.success = function(data, status, xhr, $form) {
            if (oldsuccess) {
                oldsuccess.apply(this, arguments);
            }
            if (data.success) {
                var opt = $(this).formdialog('options');
                data.data._updated = true;
                options.forgid.datagrid('reload');
                //if (opt.data.Id == 0) {
                //    options.forgid.datagrid('appendRow', data.data);
                //} else {
                //    var rowindex = options.forgid.datagrid('getRowIndex', opt.data.Id);
                //    $.extend(opt.data, data.data);
                //    options.forgid.datagrid('refreshRow', rowindex);
                //}
            }
        };
        return this.formdialog(options);
    };

    //显示form对话框
    $.fn.formdialog = function(options) {
        var dlg = this;
        if (!$.isPlainObject(options)) {
            return dlg.dialog(options);
        }

        $('form', dlg).form('clear');       

        if (options.data) {
            //隐藏需要隐藏的元素
            $('.addhide,.edithide').show();
            $('*[isrequired]', dlg).validatebox({ required: true });
            $('.easyui-combotree[isrequired]', dlg).combotree({ required: true });
            
            if (options.data.Id < 1) {
                $('.addhide', dlg).hide();
                $('.addhide *[isrequired]', dlg).validatebox({ required: false });
                $('.addhide .easyui-combotree[isrequired]', dlg).combotree({ required: false });
                $('.editdisabled', dlg).attr("disabled", false);
            } else {
                $('.edithide', dlg).hide();
                $('.edithide  *[isrequired]', dlg).validatebox({ required: false });
                $('.edithide  .easyui-combotree[isrequired]', dlg).combotree({ required: false });
                $('.editdisabled', dlg).attr("disabled", true);

            }
            $(':hidden[isrequired]').validatebox({ required: false });

        }


        //绑定保存当前要编辑的数据到页面元素
        if (options.data) {
            var data = options.data;
            if ($.isFunction(options.data)) {
                data = options.data();
            }
            $(':input', dlg).binddata(data);
        }

        var opt = $.extend({ }, {
            buttons: [{
                    text: options.submittext == undefined || options.submittext == "" ? '保存' : options.submittext,
                    iconCls: 'icon-ok',
                    handler: function() {
                        //var btn = $(this).linkbutton('disable'); //禁用保存按钮
                        var formOptions = {
                            defaultbefore: false,
                            beforeSubmit: function(arr, $form) {
                                var result = $form.valid();//form('validate');
                                
                                //if (!result) {
                                //    btn.linkbutton('enable'); //验证不通过则启用保存按钮
                                //}
                                if (options.beforeSubmit) {
                                    options.beforeSubmit.apply(this, arguments);
                                }
                                return result;
                            },
                            success: function(data, status, xhr, $form) {
                               // btn.linkbutton('enable');
                                if (options.success) {
                                    options.success.apply(dlg, arguments);
                                }
                                if (data.success) {
                                    $.messager.alert('提示', '保存成功', 'info');
                                    dlg.dialog('close');
                                } else {
                                    $.messager.alert('错误', '保存失败：' + data.data, 'error');
                                }
                            }
                        };

                        formOptions.dataType = options.dataType || 'json';

                        $('form', dlg).submitForm(formOptions);
                    }
                }, {
                    text: '取消',
                    iconCls: 'icon-cancel',
                    handler: function() {
                        dlg.dialog('close');
                    }
                }]
        }, options);
        return dlg.show().dialog(opt);
    };
    
    //扩展datagrid
    $.fn.datagridEx = function (opt) {
        var grd = this;
        if (!$.isPlainObject(opt)) {
            return grd.datagrid(opt);
        }
        var options = $.extend({ idField: "Id" }, opt);
        
        options.PrevOnLoadSuccess = options.onLoadSuccess;
        options.onLoadSuccess = function(data) {
            $(this).datagrid("clearSelections");
            
            var opts = $(this).datagrid('options');
            if (opts.PrevOnLoadSuccess)
                return opts.PrevOnLoadSuccess.call(this, data);
        };
        
        options.PrevOnBeforeLoad = options.onBeforeLoad;
        options.onBeforeLoad = function (arg) {

            arg.pageindex = arg.pageindex || arg.page;
            arg.pagesize = arg.rows;
            delete arg.page;
            delete arg.rows;

            var opts = $(this).datagrid('options');
            if (opts.PrevOnBeforeLoad)
                return opts.PrevOnBeforeLoad.call(this, arg);
            return true;
        };
       
        return this.datagrid(options);
    };
    
    //提交form
    $.fn.submitForm = function (options) {
        var opt = $.extend({}, { datatype: 'json', defaultbefore: true, clear: true }, options);

        //是否启用默认的检测
        //if (opt.defaultbefore) {
        //    var oldbefore = opt.beforeSubmit;
        //    opt.beforeSubmit = function (arr, $form, options) {
        //        var result = true;
        //        if (result) {
        //            result = $form.form('validate');
        //        }
        //        if (result && oldbefore) {
        //            result = oldbefore.apply(this, arguments);
        //        }
        //        return result;
        //    };
        //}
        var oldsuccess = opt.success;
        opt.success = function(data, status, xhr, $form) {
            if (!$.isPlainObject(data))
                data = data.toJson();
            if (oldsuccess) {
                oldsuccess.call(this, data, status, xhr, $form);
            }
            if (data.success && opt.clear)
                $form.form('clear');
        };
        this.ajaxSubmit(opt);
    };

    //添加
    $('a.add').click(function () {
        var gid = $(this).attr('forgid');
        var grid = $('#' + gid);
        var gform = $('#' + gid.substr(0, gid.length - 4) + 'edit');
        var dlgTitle = "添加" + (gform.attr('dlgtitle') || '');

     
        var pvalue = $(this).attr("parentid");
        //var optdata = new Array(2);
        //optdata["id"] = 0;
        //if (pvalue != null && pvalue != undefined && pvalue != "") {
        //    optdata['parentid'] = pvalue;
        //}
        
        var url = grid.attr('edit');
        
        $.post(url, { id: 0, parentid: pvalue }, function (data) {
            gform.gridform({ data: data.data, title: dlgTitle, forgid: grid });
        }, 'json');
 
        return false;

    });

    //查询
    $('a.search').click(function () {
        var queryparam = $(":input", $(this).parent()).SerializeElements();
        queryparam._IsSearch = true;
        //queryparam.pageindex = 1;
        var grid = $("#" + this.id + "_list").datagrid({ pageNumber: 1, queryParams: queryparam });
        return false;

    });
    
    //编辑
    $('a.edit').live('click', function () {
        var gid = $(this).attr('forgid');
        var grid = $('#' + gid);
        var goptions = grid.datagrid('options');
        var gform = $('#' + gid.substr(0, gid.length - 4) + 'edit');

        //获取选中的数据
        var rec = grid.datagrid("getSelected");
        if (rec == null) {
            return false;
        }

        if (goptions.onEdit) {
            rec = goptions.onEdit(grid, gform, rec) || rec;
        }
        var title = "编辑" + (gform.attr('dlgtitle') || '');
        
        var url = grid.attr('edit');
        $.post(url , { id: rec.Id }, function (data) {
            gform.gridform({ data: data.data, title: title, forgid: grid });
        }, 'json');
 
        
        //if (goptions.onShowEdit) {
        //    goptions.onShowEdit(grid, gform, rec);
        //}

        return false;
    });


    //删除
    $('a.del').live('click', function () {

        var grid = $('#' + $(this).attr('forgid'));
        var rec = grid.datagrid("getSelected");
        if (rec==null) {
            return false;
        }
        
        $.messager.confirm('提示', '确定要删除选中的数据吗？', function (b) {
            if (b) {
                var url = grid.attr('del');
                $.post(url, { id: rec.Id }, function (data) {
                    if (data.success) {

                        $.messager.alert('提示', '删除成功！', 'info', function () {
                            grid.datagrid('reload');
                        });
                    } else {
                        $.messager.alert('错误', '删除失败：' + data.data, 'error');
                    }
                }, 'json');
            }
        });
    });
  
});