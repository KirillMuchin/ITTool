const { src, dest, watch, parallel, series } = require('gulp');
const scss = require('gulp-sass');
const concat = require('gulp-concat');
const uglify = require('gulp-uglify-es').default;
const autoprefixer = require('gulp-autoprefixer');
const imagemin = require('gulp-imagemin');
const del = require('del');
scss.compiler = require('node-sass');


function cleanDist() {
    return del('dist')
}

function styles() {
    return src('wwwroot/sass/style.scss',
            'node_modules/@splidejs/splide/dist/css/splide.min.css')
        .pipe(scss({ outputStyle: 'compressed' }))
        .pipe(concat('style.min.css'))
        .pipe(autoprefixer({
            overrideBrowserslist: ['last 10 versions'],
            grid: true
        }))
        .pipe(dest('wwwroot/css'))
}

function scripts() {
    return src([
        'node_modules/jquery/dist/jquery.js',
        'wwwroot/js/site.js',
        ])
        .pipe(concat('site.min.js'))
        .pipe(uglify())
        .pipe(dest('wwwroot/js'))
}

function build() {
    return src([
        'wwwroot/css/style.min.css',
        'wwwroot/fonts/**/*',
        'wwwroot/js/site.min.js',
        'wwwroot/*.html'
    ], { base: 'wwwroot' })
        .pipe(dest('dist'))
}

function images() {
    return src('wwwroot/img/**/*')
        .pipe(imagemin([
            imagemin.gifsicle({ interlaced: true }),
            imagemin.mozjpeg({ quality: 75, progressive: true }),
            imagemin.optipng({ optimizationLevel: 5 }),
            imagemin.svgo({
                plugins: [
                    { removeViewBox: true },
                    { cleanupIDs: false }
                ]
            })
        ]))
        .pipe(dest('wwwroot/img'))
}

function watching() {
    watch(['wwwroot/sass/**/*.scss'], styles);
    watch(['wwwroot/js/**/*.js', '!wwwroot/js/site.min.js'], scripts);
}

exports.styles = styles;
exports.watching = watching;
exports.scripts = scripts;
exports.images = images;
exports.cleanDist = cleanDist;

exports.build = series(cleanDist, images, build);
exports.default = parallel(styles, scripts, watching);