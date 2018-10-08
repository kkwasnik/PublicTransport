Vue.component('mypage', {
  template: '#mypage',
  data() {
    return {
      options: [
        {
          title: 'Read the Docs',
          icon: 'fa fa-check-circle'
        },
        {
          title: 'View on GitHub',
          icon: 'fa fa-check-circle'
        },
        {
          title: 'View on NPM',
          icon: 'fa fa-check-circle'
        },
        {
          title: 'View Codepen Examples',
          icon: 'fa fa-check-circle'
        }
      ],
      checked: false,
      test: 'clik me',
      option: '',
      currentTab: 'mypage',
      title: 'My Page'
    }
  },
  methods: {
    submit: function (event) {
      if (this.test === '11111111') {

        this.test = '2222222';
      }
      else {
        this.test = '11111111';
      }
    }
  }
})
