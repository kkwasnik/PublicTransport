Vue.component('sale', {
  template: '#sale',
  props: {
    timeBetweenRequests: {
      type: Number,
      default: 15
	  }
  },
	data() {
		return {
			activetab: 2,
			title: 'Transaction Form',
			ticketDescription: '- 50% student discount',
			showAlert: false,
			showWarning: false,
			entered: false,
			sale: false,
			showModal: false,
			alertType: 'success',
			AlertInside: '</br>Your request has been sent.',
			timeout: this.timeBetweenRequests,
			normalAlertTimeout: 3,
			lastRequestSentTime: null,
			currentDate: null,
			timeDifference: null,
			ticketType: 'Any',
			tickets: [],
			parkingTickets: [],
			ticketsToExtend: []
		}
	},
	methods: {
		submit: function (event) {
			if (this.lastRequestSentTime === null) {
				this.showAlert = true;
				this.lastRequestSentTime = new Date().getTime();
				//call submit to core

				this.updateCoutDown();
			}
			else {
				this.timeDifference = (this.currentDate - this.lastRequestSentTime) / 1000;
				if (this.timeDifference > this.timeBetweenRequests) {
					//call submit to core
					this.showAlert = true;
					this.lastRequestSentTime = new Date().getTime();

					this.updateCoutDown();
				}
				else {
					this.showWarning = true;
				}
			}

			event.preventDefault();
		},
		changeDiscount: function (event, discount) {
			this.alertType = 'info';
			var index = this.tickets.findIndex(x => x.Type == this.ticketType);
			if (discount === 'student') {
				if (this.tickets[index].Student) {
					this.AlertInside = '</br>50% student discount has been added to your ticket config'
					this.ticketDescription = "- 50% student discount"
					this.tickets[index].Resident = false;
				}
				else {
					this.AlertInside = '</br>50% student discount has been removed from your ticket config'
				}
			}
			else if (discount === 'resident') {
				if (this.tickets[index].Resident) {
					this.AlertInside = '</br>25% discount for city residents has been added to your ticket config'
					this.ticketDescription = '- 25% resident ticket'
					this.tickets[index].Student = false;
				}
				else {
					this.AlertInside = '</br>25% discount for city residents has been removed from your ticket config'
				}
			}
			else if (discount === 'everyZone') {
				if (this.tickets[index].Zone == 2) {
					this.AlertInside = '</br>Authorization to travel in every zone has been added to your ticket config'
				}
				else {
					this.AlertInside = '</br>Authorization to travel in every zone has been removed from your ticket config'
				}
			}
			else if (discount === 'parkingTicket') {
				if (this.tickets[index].Parking) {
					this.AlertInside = '</br>Additional parking ticket has been added to your ticket config'
				}
				else {
					this.AlertInside = '</br>Additional parking ticket has been removed from your ticket config'
				}
			}

			this.getAllTickets();
			this.showAlert = true;
			event.preventDefault();
		},
		getDate: function () {
			this.int1 = window.setInterval(() => {
				this.currentDate = Math.trunc((new Date()).getTime());
			}, 1000);
		},
		buyTicket: function (event) {
			this.showModal = false;
			this.alertType = 'success';
			this.AlertInside = '</br>Ticket has been bought. Check your valid tickets !';
			this.showAlert = true;
			event.preventDefault();
		},
		updateCoutDown: function () {
			this.int2 = window.setInterval(() => {
				this.timeout--;
				if (this.timeout === 0) {
					this.showWarning = false;
					clearInterval(this.int2);
					this.showAlert = false;
					this.entered = false;
					this.timeout = this.timeBetweenRequests;
				}
			}, 1000);
		},
		getBaseURL: function () {
			var url = location.href;
			var baseURL = url.substring(0, url.indexOf('/', 14));
			if (baseURL.indexOf('http://localhost') != -1) {
				var url = location.href;
				var pathname = location.pathname;
				var index1 = url.indexOf(pathname);
				var index2 = url.indexOf("/", index1 + 1);
				var baseLocalUrl = url.substr(0, index2);

				return baseLocalUrl + "/";
			}
			else {
				return baseURL + "/";
			}
		},
		hubConnection: function (url, options) {
			var settings = {
				qs: null,
				logging: false,
				useDefaultPath: true
			};

			$.extend(settings, options);

			if (!url || settings.useDefaultPath) {
				url = (url || "") + "/signalr";
			}
			return new hubConnection.fn.init(url, settings);
		},
		getAllTickets: function () {
			var url = this.getBaseURL();
			var index = 0;
			var model = {};
			if (this.ticketType == 'Any') {
				model = {
					type: this.ticketType,
					zone: 2,
					student: false,
					resident: false,
					parking: false
				}
			}
			else {
				index = this.tickets.findIndex(x => x.Type == this.ticketType);
				model = {
					type: this.ticketType,
					zone: this.tickets[index].Zone,
					student: this.tickets[index].Student,
					resident: this.tickets[index].Resident,
					parking: this.tickets[index].Parking
				}
			}
			axios.post('/PublicTransport/Sale/GetTariffTickets',
				model)
				.then(response => {
					if (this.ticketType === 'Any') {
						this.tickets = response.data;
					}
					else {
						this.tickets[index].Cost = response.data[0].Cost;
						//this.tickets[index].Name = response.data[0].Name;
					}
				})
				.catch(error => {
					console.log(error.response)
				});
		},
		getParkingTickets: function () {
			var url = this.getBaseURL();
			var index = 0;
			var model = {};
			if (this.parkingTickets.length > 0) {
				index = this.parkingTickets.findIndex(x => x.Type == this.ticketType);
				model = {
					type: this.ticketType,
					resident: this.parkingTickets[index].Resident
				}
			}
			else {
				model = {
					type: 'Any',
					resident: false
				}
			}
			axios.post('/PublicTransport/Sale/GetParkingTickets',
				model)
				.then(response => {
					if (model.type === 'Any') {
						this.parkingTickets = response.data;
					}
					else {
						this.parkingTickets[index].Cost = response.data[0].Cost;
						//this.tickets[index].Name = response.data[0].Name;
					}
				})
				.catch(error => {
					console.log(error.response)
				});
		}
	},
  components: {
    bsInput: VueStrap.input,
    spinner: VueStrap.spinner,
    alert: VueStrap.alert,
    modal: VueStrap.modal,
    checkbox: VueStrap.checkbox
  },
  watch: {
	  showWarning(value) {
		  if (value && !this.entered) {
			  //this.updateCoutDown()
			  this.entered = true;
		  }
	  },
	  showAlert(value) {
		  if (value) {
			  this.int3 = window.setInterval(() => {
				  this.normalAlertTimeout--;
				  if (this.normalAlertTimeout === 0) {
					  clearInterval(this.int3);
					  this.showAlert = false;
					  this.normalAlertTimeout = 3;
				  }
			  }, 1000);
		  }
	  },
	  activetab(value) {
		  if (value === 3) {
			  //this.getParkingTickets();
		  }
	  }
  },
	mounted() {
		clearInterval(this.int1);
		clearInterval(this.int2);
		clearInterval(this.int3);
		this.getDate();
		this.getAllTickets();
		this.getParkingTickets();
	}
});
