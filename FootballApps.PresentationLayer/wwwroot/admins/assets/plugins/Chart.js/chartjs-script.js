
(function(window, document, $, undefined) {
	  "use strict";
	$(function() {

		if ($('#chart1').length) {
			var ctx = document.getElementById('chart1').getContext('2d');
			var myChart = new Chart(ctx, {
				type: 'bar', // line yerine bar chart daha uygun
				data: {
					labels: ['Galibiyet', 'Beraberlik', 'Maðlubiyet'], // Kategoriler
					datasets: [{
						label: 'Galatasaray', // Lider takým
						data: [7, 1, 0], // Galibiyet, Beraberlik, Maðlubiyet
						backgroundColor: [
							'#28a745', // Galibiyet yeþil
							'#ffc107', // Beraberlik sarý
							'#dc3545'  // Maðlubiyet kýrmýzý
						],
						borderWidth: 1
					}]
				},
				options: {
					responsive: true,
					plugins: {
						legend: { display: false }, // Tek takým olduðu için legend gereksiz
						tooltip: {
							enabled: true,
							backgroundColor: '#333',
							titleColor: '#fff',
							bodyColor: '#fff'
						}
					},
					scales: {
						x: {
							ticks: { color: '#ddd' },
							grid: { color: "rgba(221, 221, 221, 0.1)" }
						},
						y: {
							beginAtZero: true,
							ticks: { color: '#ddd', stepSize: 1 },
							grid: { color: "rgba(221, 221, 221, 0.1)" }
						}
					}
				}
			});
		}



		if ($('#barChart').length) {
			var ctx = document.getElementById("barChart").getContext('2d');
			var myChart = new Chart(ctx, {
				type: 'bar',
				data: {
					labels: ['Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa', 'Su'],
					datasets: [{
						label: 'Google',
						data: [13, 20, 4, 18, 29, 25, 8],
						backgroundColor: "rgba(255, 255, 255, 0.25)"
					}, {
						label: 'Facebook',
						data: [31, 30, 6, 6, 21, 4, 11],
						backgroundColor: "#fff"
					}]
				},
			options: {
				legend: {
				  display: true,
				  labels: {
					fontColor: '#ddd',  
					boxWidth:40
				  }
				},
				tooltips: {
				  enabled:false
				},	
			  scales: {
				  xAxes: [{
					  barPercentage: .5,
					ticks: {
						beginAtZero:true,
						fontColor: '#ddd'
					},
					gridLines: {
					  display: true ,
					  color: "rgba(221, 221, 221, 0.08)"
					},
				  }],
				   yAxes: [{
					ticks: {
						beginAtZero:true,
						fontColor: '#ddd'
					},
					gridLines: {
					  display: true ,
					  color: "rgba(221, 221, 221, 0.08)"
					},
				  }]
				 }

			 }
			});
		}

		if ($('#polarChart').length) {
			var ctx = document.getElementById("polarChart").getContext('2d');
			var myChart = new Chart(ctx, {
				type: 'polarArea',
				data: {
					labels: ["Lable1", "Lable2", "Lable3", "Lable4"],
					datasets: [{
						backgroundColor: [
							"rgba(255, 255, 255, 0.35)",
							"#ffffff",
							"rgba(255, 255, 255, 0.12)",
							"rgba(255, 255, 255, 0.71)"
						],
						data: [13, 20, 11, 18],
						borderWidth: [0, 0, 0, 0]
					}]
				},
			options: {
			   legend: {
				 position :"right",	
				 display: true,
				    labels: {
					  fontColor: '#ddd',  
					  boxWidth:15
				   }
				},
			scale: {
				  gridLines: {
					   color: "rgba(221, 221, 221, 0.12)" 
					 }, 
				}
			   }
			});
		}


		if ($('#pieChart').length) {
			var ctx = document.getElementById("pieChart").getContext('2d');
			var myChart = new Chart(ctx, {
				type: 'pie',
				data: {
					labels: ["Lable1", "Lable2", "Lable3", "Lable4"],
					datasets: [{
						backgroundColor: [
							"rgba(255, 255, 255, 0.35)",
							"#ffffff",
							"rgba(255, 255, 255, 0.12)",
							"rgba(255, 255, 255, 0.71)"
						],
						data: [13, 120, 11, 20],
						borderWidth: [0, 0, 0, 0]
					}]
				},
			options: {
			   legend: {
				 position :"right",	
				 display: true,
				    labels: {
					  fontColor: '#ddd',  
					  boxWidth:15
				   }
				}
			   }
			});
		}


		if ($('#doughnutChart').length) {
			var ctx = document.getElementById("doughnutChart").getContext('2d');
			var myChart = new Chart(ctx, {
				type: 'doughnut',
				data: {
					labels: ["Lable1", "Lable2", "Lable3", "Lable4"],
					datasets: [{
						backgroundColor: [
							"rgba(255, 255, 255, 0.35)",
							"#ffffff",
							"rgba(255, 255, 255, 0.12)",
							"rgba(255, 255, 255, 0.71)"
						],
						data: [13, 120, 11, 20],
						borderWidth: [0, 0, 0, 0]
					}]
				},
			options: {
			   legend: {
				 position :"right",	
				 display: true,
				    labels: {
					  fontColor: '#ddd',  
					  boxWidth:15
				   }
				}
			   }
			});
		}


	});

})(window, document, window.jQuery);