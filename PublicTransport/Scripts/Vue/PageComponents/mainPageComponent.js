Vue.component('mainpage', {
	data() {
		return {
          message: 'Krzysztof',
          currentTab: 'mypage',
          currentComponent: null,
          tabs: ['MyPage', 'History', 'Buy Ticket', 'ReportProblem']
      }
  },
  methods: {
    logOut: function () {
      this.message = "test"
    },
    reportProblem: function () {
      axios.post('/PublicTransport/LoginPannel/ReportProblem')
        .then(response => {
          this.adjustedViewFlow = response.data
        })
        .catch(error => {
          console.log(error.response)
        });
    },
    contact: function () {
      axios.post('/PublicTransport/LoginPannel/Contact')
        .then(response => {
          this.adjustedViewFlow = response.data
        })
        .catch(error => {
          console.log(error.response)
        });
    }
  },
  computed: {
    currentTabComponent: function () {
      return this.currentTab.toLowerCase()
    }
  }
});
