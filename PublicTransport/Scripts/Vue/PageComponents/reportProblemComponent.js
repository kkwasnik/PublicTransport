Vue.component('reportproblem', {
	template: '#reportproblem',
	props: {
		timeBetweenRequests: {
			type: Number,
			default: 15
		}
	},
	data() {
		return {
			files: [],
			title: 'Report Problem',
			contactReasonOptions: [
				{
					title: 'Account Problem',
					icon: 'fa fa-address-book'
				},
				{
					title: 'Card Problem',
					icon: 'fa fa-id-card'
				},
				{
					title: 'Payment Problem',
					icon: 'fa fa-credit-card-alt'
				},
				{
					title: 'Different',
					icon: 'fa fa-question-circle'
				}
			],
			reason: 'Different',
			showAlert: false,
			showWarning: false,
			entered: false,
			alertType: 'success',
			AlertInside: '</br>Your request has been sent.',
			timeout: this.timeBetweenRequests,
			lastRequestSentTime: null,
			currentDate: null,
			timeDifference: null,
			int1: null,
			int2: null
		}
	},
	methods: {
		submit: function (event) {
			if (this.lastRequestSentTime === null) {
				this.showAlert = true;
				this.lastRequestSentTime = new Date().getTime();
				//call submit

				this.updateCoutDown();
			}
			else {
				this.timeDifference = (this.currentDate - this.lastRequestSentTime) / 1000;
				if (this.timeDifference > this.timeBetweenRequests) {
					//call submit
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
		inputFilter: function (newFile, oldFile, prevent) {
			if (newFile && !oldFile) {
				// Filter non-image file
				if (!/\.(jpeg|jpe|jpg|gif|png|webp)$/i.test(newFile.name)) {
					return prevent()
				}
			}

			newFile.blob = ''
			let URL = window.URL || window.webkitURL
			if (URL && URL.createObjectURL) {
				newFile.blob = URL.createObjectURL(newFile.file)
			}
		},
		inputFile: function (newFile, oldFile) {
			if (newFile && oldFile && !newFile.active && oldFile.active) {
				// Get response data
				console.log('response', newFile.response)
				if (newFile.xhr) {
					//  Get the response status code
					console.log('status', newFile.xhr.status)
				}
			}
		},
		test: function (event) {
			if (this.alertType === 'success') {
				this.alertType = 'danger'
			}
			else {
				this.alertType = 'success'
			};

			event.preventDefault();
		},
		getDate: function () {
			this.int1 = window.setInterval(() => {
				this.currentDate = Math.trunc((new Date()).getTime());
			}, 1000);
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
		}
	},
	mounted() {
		clearInterval(this.int1);
		clearInterval(this.int2);
		this.getDate()
	}
});
