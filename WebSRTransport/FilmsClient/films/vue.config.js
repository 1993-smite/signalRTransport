// vue.config.js

/**
 * @type {import('@vue/cli-service').ProjectOptions}
 */
module.exports = {
    // options...
    css: {
        loaderOptions: {
          sass: {
            //additionalData: `@import "@/assets/_shared.scss";`,
          },
        },
      },
}