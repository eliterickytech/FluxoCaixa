/*
Template Name: Color Admin - Responsive Admin Dashboard Template build with Twitter Bootstrap 5
Version: 5.1.4
Author: Sean Ngu
Website: http://www.seantheme.com/color-admin/
*/

var handleDateRangeFilter = function () {
	$('#daterange-filter span').html(moment().subtract('days', 7).format('D MMMM YYYY') + ' - ' + moment().format('D MMMM YYYY'));
	$('#daterange-prev-date').html(moment().subtract('days', 15).format('D MMMM') + ' - ' + moment().subtract('days', 8).format('D MMMM YYYY'));

	$('#daterange-filter').daterangepicker({
		format: 'MM/DD/YYYY',
		startDate: moment().subtract(7, 'days'),
		endDate: moment(),
		minDate: '01/06/2021',
		maxDate: '07/06/2021',
		dateLimit: { days: 60 },
		showDropdowns: true,
		showWeekNumbers: true,
		timePicker: false,
		timePickerIncrement: 1,
		timePicker12Hour: true,
		ranges: {
			'Today': [moment(), moment()],
			'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
			'Last 7 Days': [moment().subtract(6, 'days'), moment()],
			'Last 30 Days': [moment().subtract(29, 'days'), moment()],
			'This Month': [moment().startOf('month'), moment().endOf('month')],
			'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
		},
		opens: 'right',
		drops: 'down',
		buttonClasses: ['btn', 'btn-sm'],
		applyClass: 'btn-primary',
		cancelClass: 'btn-default',
		separator: ' to ',
		locale: {
			applyLabel: 'Submit',
			cancelLabel: 'Cancel',
			fromLabel: 'From',
			toLabel: 'To',
			customRangeLabel: 'Custom',
			daysOfWeek: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
			monthNames: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
			firstDay: 1
		}
	}, function (start, end, label) {
		$('#daterange-filter span').html(start.format('D MMMM YYYY') + ' - ' + end.format('D MMMM YYYY'));
		var formData = {
			startDate: start.format("YYYY-MM-DD"),
			endDate: end.format("YYYY-MM-DD")
		}

		$.ajax({
			type: "GET",
			url: `/Dashboard/Filter?startDate=${start.format("YYYY-MM-DD")}&endDate=${end.format("YYYY-MM-DD")}`,
			encode: true,
			data: formData,
			dataType: "json",
			success: function (result) {
				window.location = `/Dashboard/IndexRedirect?startDate=${start.format("YYYY-MM-DD")}&endDate=${end.format("YYYY-MM-DD")}`
			},
			error: function (result) {

				console.log(result)
			}
		});

		var gap = end.diff(start, 'days');
		$('#daterange-prev-date').html(moment(start).subtract('days', gap).format('D MMMM') + ' - ' + moment(start).subtract('days', 1).format('D MMMM YYYY'));
	});
};

var DashboardV3 = function () {
	"use strict";
	return {
		//main function
		init: function () {
			handleDateRangeFilter();
		}
	};
}();

$(document).ready(function() {
	DashboardV3.init();
});