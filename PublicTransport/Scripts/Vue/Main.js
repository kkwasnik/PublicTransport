function initVue() {
  //Vue.use(VueRouter);
  //Vue.use(Vuex);
  //var router = new VueRouter({
  //  routes: [
  //    { path: '/contact/', component: contact, name: 'contact' }
  //  ]
  //});

  Vue.component('v-select', VueSelect.VueSelect);
  Vue.component('file-upload', VueUploadComponent);
  Vue.use(VueResource);
  window.EventBus = new Vue();

	var page = new Vue({
		el: '#app',
		//router: router,
		//template: '<router-view></router-view>',
		props: {
			notifications: null
		},
		data: {
		  appName: 'Public Transport'
		},
		components: {
			vSelect: VueStrap.select,
			FileUpload: VueUploadComponent
		},
		mounted() {
			//this.notifications = $.connection.notificationHub;
			//if (this.notifications.connection.id === undefined) {
			//	setTimeout(function () {
			//		//console.log("after 5sec");
			//		$.connection.hub.start();
			//	}, 5000);
			//}
		}
  })
}
