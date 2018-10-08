var vueinput = Vue.component('alert', {
  template: '#alert',
  props: {
    type: {
      type: String
    },
    dismissable: {
      type: Boolean,
      default: false
    },
    show: {
      type: Boolean,
      default: true,
      twoWay: true
    },
    duration: {
      type: Number,
      default: 0
    },
    width: {
      type: String
    },
    placement: {
      type: String
    }
  },
  watch: {
    show(val) {
      if (this._timeout) clearTimeout(this._timeout)
      if (val && Boolean(this.duration)) {
        this._timeout = setTimeout(() => {
          this.$emit('update:show', false );
        }, this.duration)
      }
    }
  }
});
