<template>
    <ol-geom-point :coordinates="coord"></ol-geom-point>
    <ol-style>
        <ol-style-circle :radius="radius">
            <ol-style-fill color="white"></ol-style-fill>
            <ol-style-stroke :color="color" :width="4"></ol-style-stroke>
            <ol-style-text :text="text" ></ol-style-text>
        </ol-style-circle>
    </ol-style>
</template>

<script>
export default {
  name: 'CirclePoint',
  props: {
    coord: {
      type: Array,
      default() { return [0,0]; } 
    },
    color: {
      type: String,
      default: '#ee6e73'
    },
    text: {
      type: String,
      default: ''
    },
    radius: {
      type: Number,
      default: 10
    }
  },
  data: ()=>{
    return {
      styles: {
        //strokeWidth: Math.ceil(this.props.radius * 0.4),
      }
    }
  },

  methods: {
    
  },
  mounted(){
    
  },
}
</script>