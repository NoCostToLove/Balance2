using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Balance2.Content.Projectiles
{
    public class SpearTungstenProjectile : ModProjectile
    {
        public override string Texture => "Balance2/Assets/Textures/Projectiles/SpearTungstenProjectile";
        public override void SetDefaults()
        {
            Projectile.width = 15;
            Projectile.height = 15;
            Projectile.scale = 1.45f;
            Projectile.penetrate = -1;
            Projectile.aiStyle = 19;
            Projectile.alpha = 0;

            Projectile.DamageType = DamageClass.Melee;
            Projectile.ownerHitCheck = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
        }

        public float movementFactor
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];
            Vector2 mountedCenter = owner.RotatedRelativePoint(owner.MountedCenter, true);
            owner.heldProj = Projectile.whoAmI;
            owner.itemTime = owner.itemAnimation;
            Projectile.direction = owner.direction;

            Projectile.position.X = mountedCenter.X - (float)(Projectile.width / 2);
            Projectile.position.Y = mountedCenter.Y - (float)(Projectile.height / 2);

            if(!owner.frozen)
            {
                if(movementFactor == 0)
                {
                    movementFactor = 3f;
                    Projectile.netUpdate = true;
                }

                if(owner.itemAnimation < owner.itemAnimationMax / 3)
                {
                    movementFactor -= 2.4f;
                }
                else
                {
                    movementFactor += 2.1f;
                }
            }

            Projectile.position += Projectile.velocity * movementFactor;

            if(owner.itemAnimation == 0)
            {
                Projectile.Kill();
            }

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);

            if(Projectile.direction == -1)
            {
                Projectile.rotation -= MathHelper.ToRadians(90f);
            }
        }
    }
}
