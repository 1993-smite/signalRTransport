<template>
    <ol-geom-line-string 
        :coordinates="path"
        title="line"
        v-on:click="clickLine()"
        ></ol-geom-line-string>
    <ol-style>
        <ol-style-stroke 
            :color="color" 
            :width="width"></ol-style-stroke>  
        <ol-style-text :text="text" ></ol-style-text>        
    </ol-style>
</template>

<script>
export default {
  name: 'Path',
  props: {
    path: {
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
    width: {
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
    clickLine: function(){
        console.log('test dfsd');
    }
  },
  mounted(){
    
  },
}
</script>