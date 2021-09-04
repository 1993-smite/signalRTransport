<template>
    <div>
        <div class="row">
            <div class="col s9">
                <video controls
                    ref="video"
                    :src="activePath">
                </video>
            </div>
            <div class="col s3">
                <table>
                    <thead>
                        <tr>
                            <th>Play List</th>
                        </tr>
                    </thead>

                    <tbody>
                        <tr v-for="item in playList.list"
                            :key="item.name"
                            @click.stop="setActive(item)"
                            :class="{ active: isActive(item) }">
                            <td>{{item.name}}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>

<script>
    import { ref, reactive, computed } from 'vue'
    import list from '@/libs/playList.js'
    import M from 'materialize-css'

    export default {
        setup(){
            /**
             * play list
             */
            let playList = reactive(list);
            
            /**
             * active methods
             */
            let active = reactive({ name: '' });
            let setActive = (item)=>{
                active.name = item.name;

                let video = this.video;
                video.load();
            }

            let isActive = (item)=>{
                return active.name === item.name;
            }

            const activePath = computed(() => {
                let path = ""
                try{
                    path = playList.getPath(active);
                }
                catch(e){
                    console.error(e);
                    M.toast({html: e});
                }
                return path;
            });

            /**
             * element video
             */
            const video = ref(null);

            return {
                playList,
                active,
                setActive,
                isActive,
                activePath,
                video
            }
        },
        mounted(){
            let context = this;

            M.updateTextFields();

            setTimeout(()=>{
                let first = context.playList.list[0];
                context.setActive(first);
            }, 100)
        }
    }
</script>

<style scoped>
    .active{
        background-color: chartreuse;
    }
    .row{
        margin-top: 5px;
    }
    video{
        height: 100%;
        width: 100%;
    }
</style>