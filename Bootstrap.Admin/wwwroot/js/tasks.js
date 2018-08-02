﻿$(function () {
    var $btnRefresh = $('#refreshTask');

    var htmlTask = '<li class="list-primary"><i class="fa fa-ellipsis-v"></i><div class="task-title notifi"><span class="task-title-sp">{0}</span><span class="task-value">{1}</span><span class="task-time">{2}</span><div class="pull-right hidden-phone"><button class="btn btn-success btn-xs fa fa-check" data-id="{3}" data-result="1"></button><button class="btn btn-danger btn-xs fa fa-remove" data-id="{3}" data-result="0" data-placement="left" data-original-title="拒绝授权"></button></div></div></li>';

    function listData() {
        $btnRefresh.toggleClass('fa-spin');
        $.bc({
            url: Tasks.url, method: 'GET', swal: false,
            callback: function (result) {
                if (result) {
                    var content = result.map(function (task) {
                        return $.format(htmlTask, task.TaskName, task.UserName, task.AssignTime, task.Id);
                    }).join('');
                    $('#list-task').html(content);
                }
                $btnRefresh.toggleClass('fa-spin');
            }
        });
    }
    listData();

    $btnRefresh.on('click', function () {
        listData();
    });
})