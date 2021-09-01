<template>
    <div>
        <div class="row">
            <div class="col s9">
                <video>
                </video>
            </div>
            <div class="col s3">
                <table>
                    <thead>
                        <tr>
                            <th>Название</th>
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
    import { reactive } from 'vue'
    import list from '@/libs/playList.js'
    import M from 'materialize-css'

    export default {
        setup(){
            let playList = reactive(list);
            let active = reactive({ name: '' });

            let setActive = (item)=>{
                active.name = item.name;
            }

            let isActive = (item)=>{
                return active.name === item.name;
            }

            return {
                playList,
                active,
                setActive,
                isActive
            }
        },
        mounted(){
            M.updateTextFields();
        }
    }
</script>

<style scoped>
    .active{
        background-color: chartreuse;
    }
</style>