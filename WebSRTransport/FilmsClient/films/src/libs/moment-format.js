import moment from 'moment';

let MomentFormat = {

    getDateFormat: function(dt){
        const date = moment(dt);
        return date.local('ru-ru').format('D MMMM');
    }
}
export default MomentFormat;