extern number ex = 1.0f;
extern number ey = 0.0f;

vec4 effect(vec4 color, Image texture, vec2 tc, vec2 sc)
{
  vec4 tcolor = Texel(texture, tc);


  number alpha = 2*texture2D( texture, tc).a;

if( alpha == 0.0 ){
  return vec4(0,0,0,0);
}

  alpha -= texture2D( texture, tc + vec2( 0.001f * ex, 0.0f ) ).a;
  alpha -= texture2D( texture, tc + vec2( 0.0f, 0.001f * ey ) ).a;

if( alpha < 1.0 ) {
  return vec4(tcolor.r, tcolor.g, tcolor.b, 1);
}
  return vec4(
    (tcolor.r + 293.0/255.0) * 0.4,
    (tcolor.g + 216.0/255.0) * 0.4,
    (tcolor.b + 161.0/255.0) * 0.4,
    1);


}
