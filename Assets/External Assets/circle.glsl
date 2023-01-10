extern number px = 0.0f;
extern number py = 0.0f;
extern number GAME_W = 0.0f;
extern number GAME_H = 0.0f;
extern number time = 0.0f;
extern number fade_tmp = 0.0f;

vec4 effect(vec4 color, Image texture, vec2 tc, vec2 sc)
{
  vec4 tcolor = Texel(texture, tc);

  vec2 scale = vec2(GAME_W, GAME_H);

  number s2 = min(GAME_W, GAME_H) * 2;

  number dist = distance((sc - scale/2 ) / s2, vec2(px, py) / s2);

  number val = dist;

  number stime = sin(time * 10) * 0.001;

  number alpha = 
    step(fade_tmp + stime, dist) * 0.4 +
    step(fade_tmp + stime + 0.05, dist) * 0.4;


  return vec4(0, 0, 0, alpha);
}
