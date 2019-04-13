/**
 * @Package: Complete Admin Responsive Theme
 * @Since: Complete Admin 1.0
 * This file is part of Complete Admin Responsive Theme.
 */


jQuery(function($) {

    'use strict';

    var CMPLTADMIN_SETTINGS = window.CMPLTADMIN_SETTINGS || {};





    /*--------------------------------
         Window Based Layout
     --------------------------------*/
    CMPLTADMIN_SETTINGS.windowBasedLayout = function() {
        var width = window.innerWidth;
        //console.log(width);

        if ($("body").hasClass("chat-open") || $("body").hasClass("sidebar-collapse")) {

            CMPLTADMIN_SETTINGS.mainmenuCollapsed();

        } else if (width < 767) {

            // small window
            $(".page-topbar").addClass("sidebar_shift").removeClass("chat_shift");
            $(".page-sidebar").addClass("collapseit").removeClass("expandit");
            $("#main-content").addClass("sidebar_shift").removeClass("chat_shift");
            $(".page-chatapi").removeClass("showit").addClass("hideit");
            $(".chatapi-windows").removeClass("showit").addClass("hideit");
            CMPLTADMIN_SETTINGS.mainmenuCollapsed();

        } else {

            // large window
            $(".page-topbar").removeClass("sidebar_shift chat_shift");
            $(".page-sidebar").removeClass("collapseit chat_shift");
            $("#main-content").removeClass("sidebar_shift chat_shift");
            CMPLTADMIN_SETTINGS.mainmenuScroll();
        }


    }


    /*--------------------------------
         Window Based Layout
     --------------------------------*/
    CMPLTADMIN_SETTINGS.onLoadTopBar = function() {
        
            $(".page-topbar .message-toggle-wrapper").addClass("showopacity");
            $(".page-topbar .notify-toggle-wrapper").addClass("showopacity");
            $(".page-topbar .searchform").addClass("showopacity");
            $(".page-topbar li.profile").addClass("showopacity");
    }


    /*--------------------------------
         CHAT API
     --------------------------------*/
    CMPLTADMIN_SETTINGS.chatAPI = function() {


        $('.page-topbar .toggle_chat').on('click', function() {
            var chatarea = $(".page-chatapi");
            var chatwindow = $(".chatapi-windows");
            var topbar = $(".page-topbar");
            var mainarea = $("#main-content");
            var menuarea = $(".page-sidebar");

            if (chatarea.hasClass("hideit")) {
                chatarea.addClass("showit").removeClass("hideit");
                chatwindow.addClass("showit").removeClass("hideit");
                topbar.addClass("chat_shift");
                mainarea.addClass("chat_shift");
                menuarea.addClass("chat_shift");
                CMPLTADMIN_SETTINGS.mainmenuCollapsed();
            } else {
                chatarea.addClass("hideit").removeClass("showit");
                chatwindow.addClass("hideit").removeClass("showit");
                topbar.removeClass("chat_shift");
                mainarea.removeClass("chat_shift");
                menuarea.removeClass("chat_shift");
                //CMPLTADMIN_SETTINGS.mainmenuScroll();
                CMPLTADMIN_SETTINGS.windowBasedLayout();
            }
        });

        $('.page-topbar .sidebar_toggle').on('click', function() {
            var chatarea = $(".page-chatapi");
            var chatwindow = $(".chatapi-windows");
            var topbar = $(".page-topbar");
            var mainarea = $("#main-content");
            var menuarea = $(".page-sidebar");

            if (menuarea.hasClass("collapseit") || menuarea.hasClass("chat_shift")) {
                menuarea.addClass("expandit").removeClass("collapseit").removeClass("chat_shift");
                topbar.removeClass("sidebar_shift").removeClass("chat_shift");
                mainarea.removeClass("sidebar_shift").removeClass("chat_shift");
                chatarea.addClass("hideit").removeClass("showit");
                chatwindow.addClass("hideit").removeClass("showit");
                CMPLTADMIN_SETTINGS.mainmenuScroll();
            } else {
                menuarea.addClass("collapseit").removeClass("expandit").removeClass("chat_shift");
                topbar.addClass("sidebar_shift").removeClass("chat_shift");
                mainarea.addClass("sidebar_shift").removeClass("chat_shift");
                CMPLTADMIN_SETTINGS.mainmenuCollapsed();
            }
        });

    };


    /*--------------------------------
         CHAT API Scroll
     --------------------------------*/
    CMPLTADMIN_SETTINGS.chatApiScroll = function() {

        var topsearch = $(".page-chatapi .search-bar").height();
        var height = window.innerHeight - topsearch;
        /*$('.chat-wrapper').height(height).perfectScrollbar({
            suppressScrollX: true
        });*/
        $('.chat-wrapper').height(height);
        const pschatapi = new PerfectScrollbar('.chat-wrapper', {
            suppressScrollX: true
        });
    };


    /*--------------------------------
         CHAT API window
     --------------------------------*/
    CMPLTADMIN_SETTINGS.chatApiWindow = function() {

        var chatarea = $(".page-chatapi");

        $('.page-chatapi .user-row').on('click', function() {

            var name = $(this).find(".user-info h4 a").html();
            var img = $(this).find(".user-img a img").attr("src");
            var id = $(this).attr("data-user-id");
            var status = $(this).find(".user-info .status").attr("data-status");

            if ($(this).hasClass("active")) {
                $(this).toggleClass("active");

                $(".chatapi-windows #user-window" + id).hide();

            } else {
                $(this).toggleClass("active");

                if ($(".chatapi-windows #user-window" + id).length) {

                    $(".chatapi-windows #user-window" + id).removeClass("minimizeit").show();

                } else {
                    var msg = chatformat_msg('Wow! What a Beautiful theme!', 'receive', name);
                    msg += chatformat_msg('Yes! Complete Admin Theme ;)', 'sent', 'You');
                    var html = "<div class='user-window' id='user-window" + id + "' data-user-id='" + id + "'>";
                    html += "<div class='controlbar'><img src='" + img + "' data-user-id='" + id + "' rel='tooltip' data-animate='animated fadeIn' data-toggle='tooltip' data-original-title='" + name + "' data-placement='top' data-color-class='primary'><span class='status " + status + "'><i class='fa fa-circle'></i></span><span class='name'>" + name + "</span><span class='opts'><i class='fa fa-times closeit' data-user-id='" + id + "'></i><i class='fa fa-minus minimizeit' data-user-id='" + id + "'></i></span></div>";
                    html += "<div class='chatarea'>" + msg + "</div>";
                    html += "<div class='typearea'><input type='text' data-user-id='" + id + "' placeholder='Type & Enter' class='form-control'></div>";
                    html += "</div>";
                    $(".chatapi-windows").append(html);
                }
            }

        });

        $(document).on('click', ".chatapi-windows .user-window .controlbar .closeit", function(e) {
            var id = $(this).attr("data-user-id");
            $(".chatapi-windows #user-window" + id).hide();
            $(".page-chatapi .user-row#chat_user_" + id).removeClass("active");
        });

        $(document).on('click', ".chatapi-windows .user-window .controlbar img, .chatapi-windows .user-window .controlbar .minimizeit", function(e) {
            var id = $(this).attr("data-user-id");

            if (!$(".chatapi-windows #user-window" + id).hasClass("minimizeit")) {
                $(".chatapi-windows #user-window" + id).addClass("minimizeit");
                CMPLTADMIN_SETTINGS.tooltipsPopovers();
            } else {
                $(".chatapi-windows #user-window" + id).removeClass("minimizeit");
            }

        });

        $(document).on('keypress', ".chatapi-windows .user-window .typearea input", function(e) {
            if (e.keyCode == 13) {
                var id = $(this).attr("data-user-id");
                var msg = $(this).val();
                msg = chatformat_msg(msg, 'sent', 'You');
                $(".chatapi-windows #user-window" + id + " .chatarea").append(msg);
                $(this).val("");
                $(this).focus();
            }
            if($(".chatapi-windows #user-window" + id + " .chatarea").length){
            /*$(".chatapi-windows #user-window" + id + " .chatarea").perfectScrollbar({
                suppressScrollX: true
            });*/
                const pschatwindows = new PerfectScrollbar(".chatapi-windows #user-window" + id + " .chatarea", {
                  suppressScrollX: true
                });
            }
        });

    };

    function chatformat_msg(msg, type, name) {
        var d = new Date();
        var h = d.getHours();
        var m = d.getMinutes();
        return "<div class='chatmsg msg_" + type + "'><span class='name'>" + name + "</span><span class='text'>" + msg + "</span><span class='ts'>" + h + ":" + m + "</span></div>";
    }


    /*--------------------------------
         Login Page
     --------------------------------*/
    CMPLTADMIN_SETTINGS.loginPage = function() {

        var height = window.innerHeight;
        var formheight = $("#login").height();
        var newheight = (height - formheight) / 2;
        //console.log(height+" - "+ formheight + " / "+ newheight);
        $('#login').css('margin-top', +newheight + 'px');

        if ($('#login #user_login').length) {
            var d = document.getElementById('user_login');
            d.focus();
        }

    };



    /*--------------------------------
         Search Page
     --------------------------------*/
    CMPLTADMIN_SETTINGS.searchPage = function() {
        
        if($(".search_data .tab-pane").length){
            /*$('.search_data .tab-pane').perfectScrollbar({
                suppressScrollX: true
            });*/
            const pssearchpage = new PerfectScrollbar('.search_data .tab-pane', {
                      suppressScrollX: true
                    });
            var search = $(".search-page-input");
            if (search.length) {
                search.focus();
            }
        }
    };


    /*--------------------------------
        Viewport Checker
     --------------------------------*/
    CMPLTADMIN_SETTINGS.viewportElement = function() {

       

        // start count
        function count(options) {
            var $this = $(this);
            options = $.extend({}, options || {}, $this.data('countToOptions') || {});
            $this.countTo(options).addClass("counted");
        }
    };



    /*--------------------------------
        Sortable / Draggable Panels
     --------------------------------*/
    CMPLTADMIN_SETTINGS.draggablePanels = function() {

        if ($.isFunction($.fn.sortable)) {
            $(".sort_panel").sortable({
                connectWith: ".sort_panel",
                handle: "header.panel_header",
                cancel: ".panel_actions",
                placeholder: "portlet-placeholder"
            });
        }
    };



    /*--------------------------------
         Breadcrumb autoHidden
     --------------------------------*/
    CMPLTADMIN_SETTINGS.breadcrumbAutoHidden = function() {

        $('.breadcrumb.auto-hidden a').on('mouseover', function() {
            $(this).removeClass("collapsed");
        });
        $('.breadcrumb.auto-hidden a').on('mouseout', function() {
            $(this).addClass("collapsed");
        });

    };





    /*--------------------------------
         Section Box Actions
     --------------------------------*/
    CMPLTADMIN_SETTINGS.sectionBoxActions = function() {

        $('section.box .actions .box_toggle').on('click', function() {

            var content = $(this).parent().parent().parent().find(".content-body");
            if (content.hasClass("collapsed")) {
                content.removeClass("collapsed").slideDown(500);
                $(this).removeClass("fa-chevron-up").addClass("fa-chevron-down");
            } else {
                content.addClass("collapsed").slideUp(500);
                $(this).removeClass("fa-chevron-down").addClass("fa-chevron-up");
            }

        });

        $('section.box .actions .box_close').on('click', function() {
            content = $(this).parent().parent().parent().remove();
        });



    };






    /*--------------------------------
         Main Menu Scroll
     --------------------------------*/
    CMPLTADMIN_SETTINGS.mainmenuScroll = function() {

        //console.log("expand scroll menu");

        //var topbar = $(".page-topbar").height();
        ////console.log(topbar);
        //var projectinfo = 0; // $(".project-info").innerHeight();
        ////console.log(projectinfo);

        //var height = window.innerHeight - topbar - projectinfo;

        ///*$('.fixedscroll #main-menu-wrapper').height(height).perfectScrollbar({
        //    suppressScrollX: true
        //});*/
        //if($('.fixedscroll #main-menu-wrapper').length){
            
        //    $('.fixedscroll #main-menu-wrapper').height(height);
        //    //console.log(height);
        //    const ps = new PerfectScrollbar('.fixedscroll #main-menu-wrapper', {
        //      suppressScrollX: true
        //    });

        //}
        //    $("#main-menu-wrapper .wraplist").height('auto');


        ///*show first sub menu of open menu item only - opened after closed*/
        //// > in the selector is used to select only immediate elements and not the inner nested elements.
        //$("li.open > .sub-menu").attr("style", "display:block;");


    };


    /*--------------------------------
         Collapsed Main Menu
     --------------------------------*/
    CMPLTADMIN_SETTINGS.mainmenuCollapsed = function() {

        //if ($(".page-sidebar.chat_shift #main-menu-wrapper").length > 0 || $(".page-sidebar.collapseit #main-menu-wrapper").length > 0) {
        //    //console.log("collapse menu");
        //    var topbar = $(".page-topbar").height();
        //    var windowheight = window.innerHeight;
        //    var minheight = windowheight - topbar;
        //    var fullheight = $(".page-container #main-content .wrapper").height();

        //    var height = fullheight;

        //    if (fullheight < minheight) {
        //        height = minheight;
        //    }

        //    //$('.fixedscroll #main-menu-wrapper').perfectScrollbar('destroy');
        //        const ps = new PerfectScrollbar('.fixedscroll #main-menu-wrapper', {});
        //        ps.destroy();

        //    $('.page-sidebar.chat_shift #main-menu-wrapper .wraplist, .page-sidebar.collapseit #main-menu-wrapper .wraplist').height(height);

        //    /*hide sub menu of open menu item*/
        //    $("li.open .sub-menu").attr("style", "");

        //}

    };




    /*--------------------------------
         Main Menu
     --------------------------------*/
    CMPLTADMIN_SETTINGS.mainMenu = function() {
        $('#main-menu-wrapper li a').click(function(e) {

            if ($(this).next().hasClass('sub-menu') === false) {
                return;
            }

            //var parent = $(this).parent().parent();
            //var sub = $(this).next();

            //parent.children('li.open').children('.sub-menu').slideUp(200);
            //parent.children('li.open').children('a').children('.arrow').removeClass('open');
            //parent.children('li').removeClass('open');

            //if (sub.is(":visible")) {
            //    $(this).find(".arrow").removeClass("open");
            //    sub.slideUp(200);
            //} else {
            //    $(this).parent().addClass("open");
            //    $(this).find(".arrow").addClass("open");
            //    sub.slideDown(200);
            //}

        });

        //$("body").click(function(e) {
        //    $(".page-sidebar.collapseit .wraplist li.open .sub-menu").attr("style","");
        //    $(".page-sidebar.collapseit .wraplist li.open").removeClass("open");
        //    $(".page-sidebar.chat_shift .wraplist li.open .sub-menu").attr("style","");
        //    $(".page-sidebar.chat_shift .wraplist li.open").removeClass("open");
        //});

    };



    /*--------------------------------
         Mailbox
     --------------------------------*/
    CMPLTADMIN_SETTINGS.mailboxInbox = function() {

        $('.mail_list table .star i').click(function(e) {
            $(this).toggleClass("fa-star fa-star-o");
        });

        $('.mail_list .open-view').click(function(e) {
            window.location = 'mail-view.html';
        });

        $('.mail_view_info .labels .cc').click(function(e) {
            var ele = $(".mail_compose_cc");
            if (ele.is(":visible")) {
                ele.hide();
            } else {
                ele.show();
            }
        });

        $('.mail_view_info .labels .bcc').click(function(e) {
            var ele = $(".mail_compose_bcc");
            if (ele.is(":visible")) {
                ele.hide();
            } else {
                ele.show();
            }
        });

    };




    /*--------------------------------
         Top Bar
     --------------------------------*/
    CMPLTADMIN_SETTINGS.pageTopBar = function() {
        $('.page-topbar li.searchform .input-group-addon').click(function(e) {
            $(this).parent().parent().parent().toggleClass("focus");
            $(this).parent().parent().find("input").focus();
        });

        /*$('.page-topbar li .dropdown-menu .list').perfectScrollbar({
            suppressScrollX: true
        });*/
        //const pstopbar = new PerfectScrollbar('.page-topbar li .dropdown-menu .list', {
        //    suppressScrollX: true
        //});

    };


    /*--------------------------------
         Extra form settings
     --------------------------------*/
    CMPLTADMIN_SETTINGS.extraFormSettings = function() {

        // transparent input group focus/blur
        $('.input-group .form-control').focus(function(e) {
            $(this).parent().find(".input-group-addon").addClass("input-focus");
            $(this).parent().find(".input-group-btn").addClass("input-focus");
        });

        $('.input-group .form-control').blur(function(e) {
            $(this).parent().find(".input-group-addon").removeClass("input-focus");
            $(this).parent().find(".input-group-btn").removeClass("input-focus");
        });

    };



     

    /*--------------------------------
         DataTables
     --------------------------------*/
    CMPLTADMIN_SETTINGS.dataTablesInit = function() {

       
        if ($.isFunction($.fn.dataTable)) {

            /*--- start ---*/

            var tableex1 = $("#example-1").dataTable({
                responsive: true,
                aLengthMenu: [
                    [10, 25, 50, 100, -1],
                    [10, 25, 50, 100, "All"]
                ]
            });

            /*--- end ---*/

            /*--- start ---*/

            var tableex1 = $("#example-11").dataTable({
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ]
            });

            /*--- end ---*/


            /*--- start ---*/

            $('#example-4').dataTable();

            /*--- end ---*/

    /*--- start ---*/

    // Setup - add a text input to each footer cell
    $('#example-3 tfoot th').each( function () {
        var title = $(this).text();
        $(this).html( '<input type="text" placeholder="Search '+title+'" />' );
    } );
 
    // DataTable
    var table = $('#example-3').DataTable();
 
    // Apply the search
    table.columns().every( function () {
        var that = this;
 
        $( 'input', this.footer() ).on( 'keyup change', function () {
            if ( that.search() !== this.value ) {
                that
                    .search( this.value )
                    .draw();
            }
        } );
    } );
/*--- end ---*/
/*--- start ---*/
 var table = $('#example-2').DataTable();
     
    $('#example-2 tbody')
        .on( 'mouseenter', 'td', function () {
            var colIdx = table.cell(this).index().column;
 
            $( table.cells().nodes() ).removeClass( 'highlight' );
            $( table.column( colIdx ).nodes() ).addClass( 'highlight' );
        } );
/*--- end ---*/



var table5 = $('#example-5').DataTable();
 
    $('button.example-5-submit').click( function() {
        var data = table5.$('input, select').serialize();
        alert(
            "The following data would have been submitted to the server: \n\n"+
            data.substr( 0, 120 )+'...'
        );
        return false;
    } );




        }
    };



    /*--------------------------------
         Pretty Photo
     --------------------------------*/
    CMPLTADMIN_SETTINGS.loadPrettyPhoto = function() {

        if ($.isFunction($.fn.prettyPhoto)) {
            //Pretty Photo
            $("a[rel^='prettyPhoto']").prettyPhoto({
                social_tools: false
            });
        }
    };




    /*--------------------------------
         Gallery
     --------------------------------*/
    CMPLTADMIN_SETTINGS.isotopeGallery = function() {
        if ($.isFunction($.fn.isotope)) {

            var $portfolio_selectors = $('.portfolio-filter >li>a');
            var $portfolio = $('.portfolio-items');
            $portfolio.isotope({
                itemSelector: '.portfolio-item',
                layoutMode: 'sloppyMasonry'
            });

            $portfolio_selectors.on('click', function() {
                $portfolio_selectors.removeClass('active');
                $(this).addClass('active');
                var selector = $(this).attr('data-filter');
                $portfolio.isotope({
                    filter: selector
                });
                return false;
            });


        }
    };


    /*--------------------------------
         Full Calendar
     --------------------------------*/
    CMPLTADMIN_SETTINGS.uiCalendar = function() {


        if ($.isFunction($.fn.fullCalendar)) {

            /* initialize the external events
                 -----------------------------------------------------------------*/

            $('#external-events .fc-event').each(function() {

                // create an Event Object (http://arshaw.com/fullcalendar/docs/event_data/Event_Object/)
                // it doesn't need to have a start or end
                var eventObject = {
                    title: $.trim($(this).text()) // use the element's text as the event title
                };

                // store the Event Object in the DOM element so we can get to it later
                $(this).data('eventObject', eventObject);

                // make the event draggable using jQuery UI
                $(this).draggable({
                    zIndex: 999,
                    revert: true, // will cause the event to go back to its
                    revertDuration: 0 //  original position after the drag
                });

            });


            /* initialize the calendar
             -----------------------------------------------------------------*/

            var date = new Date();
            var d = date.getDate();
            var m = date.getMonth();
            var y = date.getFullYear();

            $('#calendar').fullCalendar({
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,basicWeek,basicDay'
                },
                editable: true,
                eventLimit: true, // allow "more" link when too many events
                droppable: true, // this allows things to be dropped onto the calendar !!!
                drop: function(date, allDay) { // this function is called when something is dropped

                    // retrieve the dropped element's stored Event Object
                    var originalEventObject = $(this).data('eventObject');

                    // we need to copy it, so that multiple events don't have a reference to the same object
                    var copiedEventObject = $.extend({}, originalEventObject);

                    // assign it the date that was reported
                    copiedEventObject.start = date;
                    copiedEventObject.allDay = allDay;

                    // render the event on the calendar
                    // the last `true` argument determines if the event "sticks" (http://arshaw.com/fullcalendar/docs/event_rendering/renderEvent/)
                    $('#calendar').fullCalendar('renderEvent', copiedEventObject, true);

                    // is the "remove after drop" checkbox checked?
                    if ($('#drop-remove').is(':checked')) {
                        // if so, remove the element from the "Draggable Events" list
                        $(this).remove();
                    }

                },
                events: [{
                    title: 'All Day Event',
                    start: new Date(y, m, 1)
                }, {
                    title: 'Long Event',
                    start: new Date(y, m, d - 5),
                    end: new Date(y, m, d - 2)
                }, {
                    id: 999,
                    title: 'Repeating Event',
                    start: new Date(y, m, d - 3, 16, 0),
                    allDay: false
                }, {
                    id: 999,
                    title: 'Repeating Event',
                    start: new Date(y, m, d + 4, 16, 0),
                    allDay: false
                }, {
                    title: 'Meeting',
                    start: new Date(y, m, d, 10, 30),
                    allDay: false
                }, {
                    title: 'Lunch',
                    start: new Date(y, m, d, 12, 0),
                    end: new Date(y, m, d, 14, 0),
                    allDay: false
                }, {
                    title: 'Conference',
                    start: new Date(y, m, d + 1, 19, 0),
                    end: new Date(y, m, d + 1, 22, 30),
                    allDay: false
                }, {
                    title: 'Staff Meeting',
                    start: new Date(y, m, 28),
                    end: new Date(y, m, 29),
                    url: 'http://google.com/'
                }]
            });





            /*Add new event*/
            // Form to add new event

            $("#add_event_form").on('submit', function(ev) {
                ev.preventDefault();

                var $event = $(this).find('.new-event-form'),
                    event_name = $event.val();

                if (event_name.length >= 3) {

                    var newid = "new" + "" + Math.random().toString(36).substring(7);
                    // Create Event Entry
                    $("#external-events").append(
                        '<div id="' + newid + '" class="fc-event bg-accent">' + event_name + '</div>'
                    );


                    var eventObject = {
                        title: $.trim($("#" + newid).text()) // use the element's text as the event title
                    };

                    // store the Event Object in the DOM element so we can get to it later
                    $("#" + newid).data('eventObject', eventObject);

                    // Reset draggable
                    $("#" + newid).draggable({
                        revert: true,
                        revertDuration: 0,
                        zIndex: 999
                    });

                    // Reset input
                    $event.val('').focus();
                } else {
                    $event.focus();
                }
            });



        }

    };



    /*--------------------------------
         Sortable (Nestable) List
     --------------------------------*/
    CMPLTADMIN_SETTINGS.nestableList = function() {

        $("#nestableList-1").on('stop.uk.nestable', function(ev) {
            var serialized = $(this).data('nestable').serialize(),
                str = '';

            str = nestableIterate(serialized, 0);

            $("#nestableList-1-ev").val(str);
        });


        function nestableIterate(items, depth) {
            var str = '';

            if (!depth)
                depth = 0;

            //console.log(items);

            jQuery.each(items, function(i, obj) {
                str += '[ID: ' + obj.itemId + ']\t' + nestableRepeat('—', depth + 1) + ' ' + obj.item;
                str += '\n';

                if (obj.children) {
                    str += nestableIterate(obj.children, depth + 1);
                }
            });

            return str;
        }

        function nestableRepeat(s, n) {
            var a = [];
            while (a.length < n) {
                a.push(s);
            }
            return a.join('');
        }
    };









    /*--------------------------------
         Tooltips & Popovers
     --------------------------------*/
    CMPLTADMIN_SETTINGS.tooltipsPopovers = function() {

        $('[data-toggle="tooltip"]').each(function() {
            var animate = $(this).attr("data-animate");
            var colorclass = $(this).attr("data-color-class");
            $(this).tooltip({
                template: '<div class="tooltip ' + animate + ' ' + colorclass + '"><div class="tooltip-arrow"></div><div class="tooltip-inner"></div></div>'
            });
        });

        $('[data-toggle="popover"]').each(function() {
            var animate = $(this).attr("data-animate");
            var colorclass = $(this).attr("data-color-class");
            $(this).popover({
                template: '<div  role="tooltip" class="popover ' + animate + ' ' + colorclass + '"><div class="arrow"></div><h3 class="popover-header"></h3><div class="popover-body"></div></div>'
            });
        });

    };





    /*--------------------------------
         iCheck
     --------------------------------*/
    CMPLTADMIN_SETTINGS.iCheck = function() {



        if ($.isFunction($.fn.iCheck)) {


            $('input[type="checkbox"].iCheck').iCheck({
                checkboxClass: 'icheckbox_minimal',
                radioClass: 'iradio_minimal',
                increaseArea: '20%'
            });


            var x;
            var colors = ["-green", "-red", "-yellow", "-blue", "-aero", "-orange", "-grey", "-pink", "-purple","-white"];

            for (x = 0; x < colors.length; x++) {

                if (x == 0) {
                    $('input.icheck-minimal').iCheck({
                        checkboxClass: 'icheckbox_minimal' + colors[x],
                        radioClass: 'iradio_minimal' + colors[x],
                        increaseArea: '20%'
                    });

                    $('input.skin-square').iCheck({
                        checkboxClass: 'icheckbox_square' + colors[x],
                        radioClass: 'iradio_square' + colors[x],
                        increaseArea: '20%'
                    });

                    $('input.skin-flat').iCheck({
                        checkboxClass: 'icheckbox_flat' + colors[x],
                        radioClass: 'iradio_flat' + colors[x],
                    });


                    $('input.skin-line').each(function() {
                        var self = $(this),
                            label = self.next(),
                            label_text = label.text();

                        label.remove();
                        self.iCheck({
                            checkboxClass: 'icheckbox_line' + colors[x],
                            radioClass: 'iradio_line' + colors[x],
                            insert: '<div class="icheck_line-icon"></div>' + label_text
                        });
                    });

                } // end x = 0

                $('input.icheck-minimal' + colors[x]).iCheck({
                    checkboxClass: 'icheckbox_minimal' + colors[x],
                    radioClass: 'iradio_minimal' + colors[x],
                    increaseArea: '20%'
                });


                $('input.skin-square' + colors[x]).iCheck({
                    checkboxClass: 'icheckbox_square' + colors[x],
                    radioClass: 'iradio_square' + colors[x],
                    increaseArea: '20%'
                });


                $('input.skin-flat' + colors[x]).iCheck({
                    checkboxClass: 'icheckbox_flat' + colors[x],
                    radioClass: 'iradio_flat' + colors[x],
                });


                $('input.skin-line' + colors[x]).each(function() {
                    var self = $(this),
                        label = self.next(),
                        label_text = label.text();

                    label.remove();
                    self.iCheck({
                        checkboxClass: 'icheckbox_line' + colors[x],
                        radioClass: 'iradio_line' + colors[x],
                        insert: '<div class="icheck_line-icon"></div>' + label_text
                    });
                });

            } // end for loop


        }
    };




    /*--------------------------------
         Form Editors
     --------------------------------*/
    CMPLTADMIN_SETTINGS.formEditors = function() {

        if ($.isFunction($.fn.wysihtml5)) {
            $('.bootstrap-wysihtml5-textarea').wysihtml5({
                toolbar: {
                    "font-styles": true, //Font styling, e.g. h1, h2, etc. Default true
                    "emphasis": true, //Italics, bold, etc. Default true
                    "lists": true, //(Un)ordered lists, e.g. Bullets, Numbers. Default true
                    "html": true, //Button which allows you to edit the generated HTML. Default false
                    "link": true, //Button to insert a link. Default true
                    "image": true, //Button to insert an image. Default true,
                    "color": true, //Button to change color of font  
                    "blockquote": true, //Blockquote  
                    "size": "none" //default: none, other options are xs, sm, lg
                }
            });


            $('.mail-compose-editor').wysihtml5({
                toolbar: {
                    "font-styles": true, //Font styling, e.g. h1, h2, etc. Default true
                    "emphasis": true, //Italics, bold, etc. Default true
                    "lists": false, //(Un)ordered lists, e.g. Bullets, Numbers. Default true
                    "html": true, //Button which allows you to edit the generated HTML. Default false
                    "link": true, //Button to insert a link. Default true
                    "image": true, //Button to insert an image. Default true,
                    "color": true, //Button to change color of font  
                    "blockquote": false, //Blockquote  
                    "size": "none" //default: none, other options are xs, sm, lg
                }
            });

        }

        if ($.isFunction($.fn.CKEDITOR)) {
            // This code is generally not necessary, but it is here to demonstrate
            // how to customize specific editor instances on the fly. This fits well
            // this demo because we have editable elements (like headers) that
            // require less features.

            // The "instanceCreated" event is fired for every editor instance created.
            CKEDITOR.on('instanceCreated', function(event) {
                var editor = event.editor,
                    element = editor.element;

                // Customize editors for headers and tag list.
                // These editors don't need features like smileys, templates, iframes etc.
                if (element.is('h1', 'h2', 'h3') || element.getAttribute('id') == 'taglist') {
                    // Customize the editor configurations on "configLoaded" event,
                    // which is fired after the configuration file loading and
                    // execution. This makes it possible to change the
                    // configurations before the editor initialization takes place.
                    editor.on('configLoaded', function() {

                        // Remove unnecessary plugins to make the editor simpler.
                        editor.config.removePlugins = 'colorbutton,find,flash,font,' +
                            'forms,iframe,image,newpage,removeformat,' +
                            'smiley,specialchar,stylescombo,templates';

                        // Rearrange the layout of the toolbar.
                        editor.config.toolbarGroups = [{
                            name: 'editing',
                            groups: ['basicstyles', 'links']
                        }, {
                            name: 'undo'
                        }, {
                            name: 'clipboard',
                            groups: ['selection', 'clipboard']
                        }, {
                            name: 'about'
                        }];
                    });
                }
            });
        }
    };


    /*--------------------------------
         Custom Dropzone
     --------------------------------*/
    CMPLTADMIN_SETTINGS.customDropZone = function() {



        if ($.isFunction($.fn.dropzone)) {

            var i = 1,
                $custom_droplist = $("#custom-droptable"),
                example_dropzone = $("#customDZ").dropzone({
                    url: 'data/upload-file.php',

                    // Events
                    addedfile: function(file) {
                        if (i == 1) {
                            $custom_droplist.find('tbody').html('');
                        }

                        var size = parseInt(file.size / 1024, 10);
                        size = size < 1024 ? (size + " KB") : (parseInt(size / 1024, 10) + " MB");

                        var $el = $('<tr>\
                                                    <td class="text-center">' + (i++) + '</td>\
                                                    <td>' + file.name + '</td>\
                                                    <td><div class="progress"><div class="progress-bar progress-bar-warning"></div></div></td>\
                                                    <td>' + size + '</td>\
                                                </tr>');

                        $custom_droplist.find('tbody').append($el);
                        file.fileEntryTd = $el;
                        file.progressBar = $el.find('.progress-bar');
                    },

                    uploadprogress: function(file, progress, bytesSent) {
                        file.progressBar.width(progress + '%');
                        /*$('.custom-dropzone .drop-table').perfectScrollbar({
                            suppressScrollX: true
                        });*/
                        const psdropzone = new PerfectScrollbar('.custom-dropzone .drop-table', {
                            suppressScrollX: true
                        });
                    },

                    success: function(file) {
                        file.progressBar.removeClass('progress-bar-warning').addClass('progress-bar-success');
                    },

                    error: function(file) {
                        file.progressBar.removeClass('progress-bar-warning').addClass('progress-bar-red');
                    }
                });

        }

    };


    /*--------------------------------
         Other Form component Scripts
     --------------------------------*/
    CMPLTADMIN_SETTINGS.otherScripts = function() {



        /*--------------------------------*/


        if ($.isFunction($.fn.autosize)) {
            $(".autogrow").autosize();
        }

        /*--------------------------------*/




        // Input Mask
        if ($.isFunction($.fn.inputmask)) {
            $("[data-mask]").each(function(i, el) {
                var $this = $(el),
                    mask = $this.data('mask').toString(),
                    opts = {
                        numericInput: getValue($this, 'numeric', false),
                        radixPoint: getValue($this, 'radixPoint', ''),
                        rightAlign: getValue($this, 'numericAlign', 'left') == 'right'
                    },
                    placeholder = getValue($this, 'placeholder', ''),
                    is_regex = getValue($this, 'isRegex', '');

                if (placeholder.length) {
                    opts[placeholder] = placeholder;
                }


                if (mask.toLowerCase() == "phone") {
                    mask = "(999) 999-9999";
                }

                if (mask.toLowerCase() == "email") {
                    mask = 'Regex';
                    opts.regex = "[a-zA-Z0-9._%-]+@[a-zA-Z0-9-]+\\.[a-zA-Z]{2,4}";
                }

                if (mask.toLowerCase() == "fdecimal") {
                    mask = 'decimal';
                    $.extend(opts, {
                        autoGroup: true,
                        groupSize: 3,
                        radixPoint: getValue($this, 'rad', '.'),
                        groupSeparator: getValue($this, 'dec', ',')
                    });
                }


                if (mask.toLowerCase() == "currency" || mask.toLowerCase() == "rcurrency") {

                    var sign = getValue($this, 'sign', '$');;

                    mask = "999,999,999.99";
                    if (mask.toLowerCase() == 'rcurrency') {
                        mask += ' ' + sign;
                    } else {
                        mask = sign + ' ' + mask;
                    }

                    opts.numericInput = true;
                    opts.rightAlignNumerics = false;
                    opts.radixPoint = '.';

                }

                if (is_regex) {
                    opts.regex = mask;
                    mask = 'Regex';
                }

                $this.inputmask(mask, opts);
            });
        }


        /*---------------------------------*/

        // autoNumeric
        if ($.isFunction($.fn.autoNumeric)) {
            $('.autoNumeric').autoNumeric('init');
        }

        /*---------------------------------*/

        // Slider
        if ($.isFunction($.fn.slider)) {
            $(".slider").each(function(i, el) {
                var $this = $(el),
                    $label_1 = $('<span class="ui-label"></span>'),
                    $label_2 = $label_1.clone(),

                    orientation = getValue($this, 'vertical', 0) != 0 ? 'vertical' : 'horizontal',

                    prefix = getValue($this, 'prefix', ''),
                    postfix = getValue($this, 'postfix', ''),

                    fill = getValue($this, 'fill', ''),
                    $fill = $(fill),

                    step = getValue($this, 'step', 1),
                    value = getValue($this, 'value', 5),
                    min = getValue($this, 'min', 0),
                    max = getValue($this, 'max', 100),
                    min_val = getValue($this, 'min-val', 10),
                    max_val = getValue($this, 'max-val', 90),

                    is_range = $this.is('[data-min-val]') || $this.is('[data-max-val]'),

                    reps = 0;


                // Range Slider Options
                if (is_range) {
                    $this.slider({
                        range: true,
                        orientation: orientation,
                        min: min,
                        max: max,
                        values: [min_val, max_val],
                        step: step,
                        slide: function(e, ui) {
                            var min_val = (prefix ? prefix : '') + ui.values[0] + (postfix ? postfix : ''),
                                max_val = (prefix ? prefix : '') + ui.values[1] + (postfix ? postfix : '');

                            $label_1.html(min_val);
                            $label_2.html(max_val);

                            if (fill)
                                $fill.val(min_val + ',' + max_val);

                            reps++;
                        },
                        change: function(ev, ui) {
                            if (reps == 1) {
                                var min_val = (prefix ? prefix : '') + ui.values[0] + (postfix ? postfix : ''),
                                    max_val = (prefix ? prefix : '') + ui.values[1] + (postfix ? postfix : '');

                                $label_1.html(min_val);
                                $label_2.html(max_val);

                                if (fill)
                                    $fill.val(min_val + ',' + max_val);
                            }

                            reps = 0;
                        }
                    });

                    var $handles = $this.find('.ui-slider-handle');

                    $label_1.html((prefix ? prefix : '') + min_val + (postfix ? postfix : ''));
                    $handles.first().append($label_1);

                    $label_2.html((prefix ? prefix : '') + max_val + (postfix ? postfix : ''));
                    $handles.last().append($label_2);
                }
                // Normal Slider
                else {

                    $this.slider({
                        range: getValue($this, 'basic', 0) ? false : "min",
                        orientation: orientation,
                        min: min,
                        max: max,
                        value: value,
                        step: step,
                        slide: function(ev, ui) {
                            var val = (prefix ? prefix : '') + ui.value + (postfix ? postfix : '');

                            $label_1.html(val);


                            if (fill)
                                $fill.val(val);

                            reps++;
                        },
                        change: function(ev, ui) {
                            if (reps == 1) {
                                var val = (prefix ? prefix : '') + ui.value + (postfix ? postfix : '');

                                $label_1.html(val);

                                if (fill)
                                    $fill.val(val);
                            }

                            reps = 0;
                        }
                    });

                    var $handles = $this.find('.ui-slider-handle');
                    //$fill = $('<div class="ui-fill"></div>');

                    $label_1.html((prefix ? prefix : '') + value + (postfix ? postfix : ''));
                    $handles.html($label_1);

                    //$handles.parent().prepend( $fill );

                    //$fill.width($handles.get(0).style.left);
                }

            })
        }



        /*------------- Color Slider widget---------------*/

        function hexFromRGB(r, g, b) {
            var hex = [
                r.toString(16),
                g.toString(16),
                b.toString(16)
            ];
            $.each(hex, function(nr, val) {
                if (val.length === 1) {
                    hex[nr] = "0" + val;
                }
            });
            return hex.join("").toUpperCase();
        }

        function refreshSwatch() {
            var red = $("#slider-red").slider("value"),
                green = $("#slider-green").slider("value"),
                blue = $("#slider-blue").slider("value"),
                hex = hexFromRGB(red, green, blue);
            $("#slider-swatch").css("background-color", "#" + hex);
        }


        if ($.isFunction($.fn.slider)) {

            $(function() {
                $("#slider-red, #slider-green, #slider-blue").slider({
                    orientation: "horizontal",
                    range: "min",
                    max: 255,
                    value: 127,
                    slide: refreshSwatch,
                    change: refreshSwatch
                });
                $("#slider-red").slider("value", 235);
                $("#slider-green").slider("value", 70);
                $("#slider-blue").slider("value", 60);
            });
        }



        /*-------------------------------------*/

        /*--------------------------------*/


        // Spinner
        if ($.isFunction($.fn.spinner)) {

                $( "#spinner" ).spinner();

                $( "#spinner2" ).spinner({
                    min: 5,
                    max: 2500,
                    step: 25,
                    start: 1000,
                    numberFormat: "C"
                });


                $( "#spinner3" ).spinner({
                    spin: function( event, ui ) {
                        if ( ui.value > 10 ) {
                            $( this ).spinner( "value", -10 );
                            return false;
                        } else if ( ui.value < -10 ) {
                            $( this ).spinner( "value", 10 );
                            return false;
                        }
                    }
                });
}
        /*------------------------------------*/

        // tagsinput
        if ($.isFunction($.fn.tagsinput)) {

            // categorize tags input
            var i = -1,
                colors = ['primary', 'info', 'warning', 'success'];

            colors = shuffleArray(colors);

            $("#tagsinput-2").tagsinput({
                tagClass: function() {
                    i++;
                    return "label label-" + colors[i % colors.length];
                }
            });


            $(".mail_compose_to").tagsinput({
                tagClass: function() {
                    i++;
                    return "label label-" + colors[i % colors.length];
                }
            });


        }

        // Just for demo purpose
        function shuffleArray(array) {
            for (var i = array.length - 1; i > 0; i--) {
                var j = Math.floor(Math.random() * (i + 1));
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return array;
        }

        /*----------------------------*/


        // datepicker
        if ($.isFunction($.fn.datepicker)) {
            $(".datepicker").each(function(i, e) {
                var $this = $(e),
                    options = {
                        minViewMode: getValue($this, 'minViewMode', 0),
                        format: getValue($this, 'format', 'mm/dd/yyyy'),
                        startDate: getValue($this, 'startDate', ''),
                        endDate: getValue($this, 'endDate', ''),
                        daysOfWeekDisabled: getValue($this, 'disabledDays', ''),
                        startView: getValue($this, 'startView', 0)
                    },
                    $nxt = $this.next(),
                    $prv = $this.prev();


                $this.datepicker(options);

                if ($nxt.is('.input-group-addon') && $nxt.has('a')) {
                    $nxt.on('click', function(ev) {
                        ev.preventDefault();
                        $this.datepicker('show');
                    });
                }

                if ($prv.is('.input-group-addon') && $prv.has('a')) {
                    $prv.on('click', function(ev) {
                        ev.preventDefault();

                        $this.datepicker('show');
                    });
                }
            });
        }



        /*-------------------------------------------*/



        // Date Range Picker
        if ($.isFunction($.fn.daterangepicker)) {
            $(".daterange").each(function(i, e) {
                // Change the range as you desire
                var ranges = {
                    'Today': [moment(), moment()],
                    'Yesterday': [moment().subtract('days', 1), moment().subtract('days', 1)],
                    'Last 7 Days': [moment().subtract('days', 6), moment()],
                    'Last 30 Days': [moment().subtract('days', 29), moment()],
                    'This Month': [moment().startOf('month'), moment().endOf('month')],
                    'Last Month': [moment().subtract('month', 1).startOf('month'), moment().subtract('month', 1).endOf('month')]
                };

                var $this = $(e),
                    options = {
                        format: getValue($this, 'format', 'MM/DD/YYYY'),
                        timePicker: getValue($this, 'timePicker', false),
                        timePickerIncrement: getValue($this, 'timePickerIncrement', false),
                        separator: getValue($this, 'separator', ' - '),
                    },
                    min_date = getValue($this, 'minDate', ''),
                    max_date = getValue($this, 'maxDate', ''),
                    start_date = getValue($this, 'startDate', ''),
                    end_date = getValue($this, 'endDate', '');

                if ($this.hasClass('add-date-ranges')) {
                    options['ranges'] = ranges;
                }

                if (min_date.length) {
                    options['minDate'] = min_date;
                }

                if (max_date.length) {
                    options['maxDate'] = max_date;
                }

                if (start_date.length) {
                    options['startDate'] = start_date;
                }

                if (end_date.length) {
                    options['endDate'] = end_date;
                }


                $this.daterangepicker(options, function(start, end) {
                    var drp = $this.data('daterangepicker');

                    if ($this.hasClass('daterange-text')) {
//                        $this.find('span').html(start.format(drp.format) + drp.separator + end.format(drp.format));
                        $this.find('span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
                    }
                });

                if (typeof options['ranges'] == 'object') {
                    $this.data('daterangepicker').container.removeClass('show-calendar');
                }
            });
        }




        /*-------------------------------------*/


        // Timepicker
        if ($.isFunction($.fn.timepicker)) {
            $(".timepicker").each(function(i, e) {
                var $this = $(e),
                    options = {
                        template: getValue($this, 'template', false),
                        showSeconds: getValue($this, 'showSeconds', false),
                        defaultTime: getValue($this, 'defaultTime', 'current'),
                        showMeridian: getValue($this, 'showMeridian', true),
                        minuteStep: getValue($this, 'minuteStep', 15),
                        secondStep: getValue($this, 'secondStep', 15)
                    },
                    $nxt = $this.next(),
                    $prv = $this.prev();

                $this.timepicker(options);

                if ($nxt.is('.input-group-addon') && $nxt.has('a')) {
                    $nxt.on('click', function(ev) {
                        ev.preventDefault();

                        $this.timepicker('showWidget');
                    });
                }

                if ($prv.is('.input-group-addon') && $prv.has('a')) {
                    $prv.on('click', function(ev) {
                        ev.preventDefault();

                        $this.timepicker('showWidget');
                    });
                }
            });
        }



        /*-------------------------------------*/


        // DateTimepicker
        if ($.isFunction($.fn.datetimepicker)) {

            $('.form_datetime').datetimepicker({
                //language:  'fr',
                format: "yyyy-mm-dd hh:ii",
                weekStart: 1,
                todayBtn: 1,
                autoclose: 1,
                todayHighlight: 1,
                startView: 2,
                forceParse: 0,
                showMeridian: 0
            });


            $('.form_datetime_meridian').datetimepicker({
                //language:  'fr',
                format: "dd MM yyyy - hh:ii",
                weekStart: 1,
                todayBtn: 1,
                autoclose: 1,
                todayHighlight: 1,
                startView: 2,
                forceParse: 0,
                showMeridian: 1
            });


            $('.form_datetime_lang').datetimepicker({
                language: 'fr',
                format: "yyyy-mm-dd hh:ii",
                weekStart: 1,
                todayBtn: 1,
                autoclose: 1,
                todayHighlight: 1,
                startView: 2,
                forceParse: 0,
                showMeridian: 0
            });


            /*    $('.form_date').datetimepicker({
                    weekStart: 1,
                    todayBtn:  1,
                    autoclose: 1,
                    todayHighlight: 1,
                    startView: 2,
                    minView: 2,
                    forceParse: 0
                });
                $('.form_time').datetimepicker({
                    //language:  'fr',
                    weekStart: 1,
                    todayBtn:  1,
                    autoclose: 1,
                    todayHighlight: 1,
                    startView: 1,
                    minView: 0,
                    maxView: 1,
                    forceParse: 0
                });*/

        }

        /*-------------------------------------*/





        // Colorpicker
        if ($.isFunction($.fn.colorpicker)) {
            $(".colorpicker").each(function(i, e) {
                var $this = $(e),
                    options = {},
                    $nxt = $this.next(),
                    $prv = $this.prev(),
                    $view = $this.siblings('.input-group-addon').find('.sel-color');

                $this.colorpicker(options);

                if ($nxt.is('.input-group-addon') && $nxt.has('a')) {
                    $nxt.on('click', function(ev) {
                        ev.preventDefault();

                        $this.colorpicker('show');
                    });
                }

                if ($prv.is('.input-group-addon') && $prv.has('a')) {
                    $prv.on('click', function(ev) {
                        ev.preventDefault();

                        $this.colorpicker('show');
                    });
                }

                if ($view.length) {
                    $this.on('changeColor', function(ev) {

                        $view.css('background-color', ev.color.toHex());
                    });

                    if ($this.val().length) {
                        $view.css('background-color', $this.val());
                    }
                }
            });
        }


        /*--------------------------------------*/


        // select2
        if ($.isFunction($.fn.select2)) {

            $("#s2example-1").select2({
                placeholder: 'Select your country...',
                allowClear: true
            }).on('select2-open', function() {
                // Adding Custom Scrollbar
                //$(this).data('select2').results.addClass('overflow-hidden').perfectScrollbar();
                $(this).data('select2').results.addClass('overflow-hidden');
                const pssel2ex1 = new PerfectScrollbar('.select2-results', {
                            suppressScrollX: true
                });
            });


            $("#s2example-2").select2({
                placeholder: 'Choose your favorite US Countries',
                allowClear: true
            }).on('select2-open', function() {
                // Adding Custom Scrollbar
                //$(this).data('select2').results.addClass('overflow-hidden').perfectScrollbar();
                $(this).data('select2').results.addClass('overflow-hidden');
                const pssel2ex2 = new PerfectScrollbar('.select2-results', {
                            suppressScrollX: true
                });
            });


            $("#s2example-4").select2({
                minimumInputLength: 1,
                placeholder: 'Search',
                ajax: {
                    url: "../data/select2-remote-data.php",
                    dataType: 'json',
                    quietMillis: 100,
                    data: function(term, page) {
                        return {
                            limit: -1,
                            q: term
                        };
                    },
                    results: function(data, page) {
                        return {
                            results: data
                        }
                    }
                },
                formatResult: function(student) {
                    return "<div class='select2-user-result'>" + student.name + "</div>";
                },
                formatSelection: function(student) {
                    return student.name;
                }

            }).on('select2-open', function() {
                // Adding Custom Scrollbar
                //$(this).data('select2').results.addClass('overflow-hidden').perfectScrollbar();
                $(this).data('select2').results.addClass('overflow-hidden');
                const pssel2ex3 = new PerfectScrollbar('.select2-results', {
                            suppressScrollX: true
                });

            });
        }
        /*------------------------------------*/




        //multiselect start

        if ($.isFunction($.fn.multiSelect)) {

            $('#my_multi_select1').multiSelect();
            $('#my_multi_select2').multiSelect({
                selectableOptgroup: true
            });

            $('#my_multi_select3').multiSelect({
                selectableHeader: "<input type='text' class='form-control search-input' autocomplete='off' placeholder='search...'>",
                selectionHeader: "<input type='text' class='form-control search-input' autocomplete='off' placeholder='search...'>",
                afterInit: function(ms) {
                    var that = this,
                        $selectableSearch = that.$selectableUl.prev(),
                        $selectionSearch = that.$selectionUl.prev(),
                        selectableSearchString = '#' + that.$container.attr('id') + ' .ms-elem-selectable:not(.ms-selected)',
                        selectionSearchString = '#' + that.$container.attr('id') + ' .ms-elem-selection.ms-selected';

                    that.qs1 = $selectableSearch.quicksearch(selectableSearchString)
                        .on('keydown', function(e) {
                            if (e.which === 40) {
                                that.$selectableUl.focus();
                                return false;
                            }
                        });

                    that.qs2 = $selectionSearch.quicksearch(selectionSearchString)
                        .on('keydown', function(e) {
                            if (e.which == 40) {
                                that.$selectionUl.focus();
                                return false;
                            }
                        });
                },
                afterSelect: function() {
                    this.qs1.cache();
                    this.qs2.cache();
                },
                afterDeselect: function() {
                    this.qs1.cache();
                    this.qs2.cache();
                }
            });

        }
        //multiselect end









        /*---------------------------------------*/


        if ($.isFunction($.fn.typeahead)) {

            // basic typeahead

            var substringMatcher = function(strs) {
                return function findMatches(q, cb) {
                    var matches, substrRegex;

                    // an array that will be populated with substring matches
                    matches = [];

                    // regex used to determine if a string contains the substring `q`
                    substrRegex = new RegExp(q, 'i');

                    // iterate through the pool of strings and for any string that
                    // contains the substring `q`, add it to the `matches` array
                    $.each(strs, function(i, str) {
                        if (substrRegex.test(str)) {
                            // the typeahead jQuery plugin expects suggestions to a
                            // JavaScript object, refer to typeahead docs for more info
                            matches.push({
                                value: str
                            });
                        }
                    });

                    cb(matches);
                };
            };

            var states = ['Alabama', 'Alaska', 'Arizona', 'Arkansas', 'California',
                'Colorado', 'Connecticut', 'Delaware', 'Florida', 'Georgia', 'Hawaii',
                'Idaho', 'Illinois', 'Indiana', 'Iowa', 'Kansas', 'Kentucky', 'Louisiana',
                'Maine', 'Maryland', 'Massachusetts', 'Michigan', 'Minnesota',
                'Mississippi', 'Missouri', 'Montana', 'Nebraska', 'Nevada', 'New Hampshire',
                'New Jersey', 'New Mexico', 'New York', 'North Carolina', 'North Dakota',
                'Ohio', 'Oklahoma', 'Oregon', 'Pennsylvania', 'Rhode Island',
                'South Carolina', 'South Dakota', 'Tennessee', 'Texas', 'Utah', 'Vermont',
                'Virginia', 'Washington', 'West Virginia', 'Wisconsin', 'Wyoming'
            ];

            $('#typeahead-1').typeahead({
                hint: true,
                highlight: true,
                minLength: 1
            }, {
                name: 'states',
                displayKey: 'value',
                source: substringMatcher(states)
            });



            // prefetch typeahead

            var names = new Bloodhound({
                datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
                queryTokenizer: Bloodhound.tokenizers.whitespace,
                limit: 10,
                prefetch: {
                    url: 'data/names.json',
                    filter: function(list) {
                        return $.map(list, function(name) {
                            return {
                                name: name
                            };
                        });
                    }
                }
            });

            names.initialize();

            $('#typeahead-2').typeahead(null, {
                name: 'names',
                displayKey: 'name',
                source: names.ttAdapter()
            });


            // remote data


            var name_randomizer = new Bloodhound({
                datumTokenizer: Bloodhound.tokenizers.obj.whitespace('value'),
                queryTokenizer: Bloodhound.tokenizers.whitespace,
                // You can also prefetch suggestions
                // prefetch: 'data/typeahead-generate.php',
                remote: '../data/typeahead-generate.php?q=%QUERY'
            });

            name_randomizer.initialize();

            $('#typeahead-3').typeahead({
                hint: true,
                highlight: true
            }, {
                name: 'string-randomizer',
                displayKey: 'value',
                source: name_randomizer.ttAdapter()
            });


            // templating

            var oscar_movies = new Bloodhound({
                datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
                queryTokenizer: Bloodhound.tokenizers.whitespace,
                remote: '../data/typeahead-hp-movies.php?q=%QUERY'
            });

            oscar_movies.initialize();

            $('#typeahead-4').typeahead(null, {
                    name: 'oscar-movies',
                    displayKey: 'value',
                    source: oscar_movies.ttAdapter(),
                    templates: {
                        empty: [
                            '<div class="empty-message">',
                            'We cannot find this movie title',
                            '</div>'
                        ].join('\n'),
                        suggestion: Handlebars.compile('<div class="clearfix" style="width:100%;display:inline-block;min-height:60px;height:auto;"><img src="data/{{cover}}" class="img-responsive pull-left" width="30" style="margin-right:10px;" /><strong>{{value}}</strong> &mdash; {{year}}<br /><span style="display:inline-block; height: 22px; overflow: hidden; white-space:nowrap; text-overflow:ellipsis; max-width: 400px;"></span></div>')
                    }
                })
                .bind('typeahead:opened', function() {
                    /*const selector = $(this).data('ttTypeahead').dropdown.$menu;
                    //console.log(selector);
                    if(selector.length){    
                        //$(this).data('ttTypeahead').dropdown.$menu.addClass('overflow-hidden').perfectScrollbar();
                        $(this).data('ttTypeahead').dropdown.$menu.addClass('overflow-hidden');
                        const pstype4 = new PerfectScrollbar(selector, {
                                suppressScrollX: true
                        });
                    }*/
                })
                .on('keyup', function() {
                    const selector1 = $(this).data('ttTypeahead').dropdown.$menu;
                    //console.log(selector1);
                    //$(this).data('ttTypeahead').dropdown.$menu.perfectScrollbar('update');
                    /*if(selector1.length){
                        const pstype4update = new PerfectScrollbar(selector1, {
                                suppressScrollX: true
                        });
                        pstype4update.update();
                    }*/
                });

        }
        /*------------------------------------*/



        /*------------------------------------------*/

    };



    /*--------------------------------
        Widgets
     --------------------------------*/
    CMPLTADMIN_SETTINGS.cmpltadminWidgets = function() {

        /*notification widget*/
        if($(".notification-widget").length){
            var notif_widget = $(".notification-widget").height();
            /*$('.notification-widget').height(notif_widget).perfectScrollbar({
                suppressScrollX: true
            });*/
            $('.notification-widget').height(notif_widget);
            const psnotifwidget = new PerfectScrollbar('.notification-widget', {
              suppressScrollX: true
            });
        }
    };


      

    // Element Attribute Helper
    function getValue($el, data_var, default_val) {
        if (typeof $el.data(data_var) != 'undefined') {
            return $el.data(data_var);
        }

        return default_val;
    }


    /******************************
     initialize respective scripts 
     *****************************/
    $(document).ready(function() {
        CMPLTADMIN_SETTINGS.windowBasedLayout();
        CMPLTADMIN_SETTINGS.mainmenuScroll();
        CMPLTADMIN_SETTINGS.mainMenu();
        CMPLTADMIN_SETTINGS.mainmenuCollapsed();
        CMPLTADMIN_SETTINGS.pageTopBar();
        CMPLTADMIN_SETTINGS.otherScripts();
        CMPLTADMIN_SETTINGS.iCheck();
        CMPLTADMIN_SETTINGS.customDropZone();
        CMPLTADMIN_SETTINGS.formEditors();
        CMPLTADMIN_SETTINGS.extraFormSettings();
        CMPLTADMIN_SETTINGS.tooltipsPopovers();
        CMPLTADMIN_SETTINGS.nestableList();
        CMPLTADMIN_SETTINGS.uiCalendar();
        CMPLTADMIN_SETTINGS.loadPrettyPhoto();
        CMPLTADMIN_SETTINGS.dataTablesInit();
        CMPLTADMIN_SETTINGS.breadcrumbAutoHidden();
        CMPLTADMIN_SETTINGS.chatAPI();
        CMPLTADMIN_SETTINGS.mailboxInbox();
        CMPLTADMIN_SETTINGS.cmpltadminWidgets();
        CMPLTADMIN_SETTINGS.sectionBoxActions();
        CMPLTADMIN_SETTINGS.draggablePanels();
        CMPLTADMIN_SETTINGS.viewportElement();
        CMPLTADMIN_SETTINGS.searchPage();
        CMPLTADMIN_SETTINGS.onLoadTopBar();
    });

    window.Resizer = {
        Resize: function () {
            CMPLTADMIN_SETTINGS.windowBasedLayout();
            CMPLTADMIN_SETTINGS.mainMenu();
            CMPLTADMIN_SETTINGS.mainmenuCollapsed();
            return "";
        }
    };

    $(window).resize(function() {
        CMPLTADMIN_SETTINGS.windowBasedLayout();
        //CMPLTADMIN_SETTINGS.mainmenuScroll();
        //CMPLTADMIN_SETTINGS.cmpltadminWidgetWeather();
        CMPLTADMIN_SETTINGS.isotopeGallery();
        CMPLTADMIN_SETTINGS.loginPage();
        
    });

    $(window).on('load', function () {
        CMPLTADMIN_SETTINGS.isotopeGallery();
        CMPLTADMIN_SETTINGS.loginPage();
        
    });

});
